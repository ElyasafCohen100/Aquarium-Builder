using System.Net;
using System.Text.Json;
using AquariumBuilder.Backend.Dtos.Common;
using AquariumBuilder.Backend.Exceptions.Fish;
using AquariumBuilder.Backend.Exceptions.BreedingBox;


namespace AquariumBuilder.Backend.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; // Like a "button" that takes you to the next middleware

        // ====== constructors ====== //
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        // ====== methods ====== // 

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {   
                await this._next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                // ====== map exception to status code ====== //
                int statusCode = ex switch
                {

                    // ===== Fish ===== //
                    FishNotFoundException => StatusCodes.Status404NotFound,


                    // ===== BreedingBox ===== //
                    BreedingBoxNotFoundException => StatusCodes.Status404NotFound,
                    NoFishInBreedingBoxException => StatusCodes.Status409Conflict,
                  
                    BreedingBoxIsNotFreeException => StatusCodes.Status409Conflict,
                    BreedingBoxIsAlreadyFreeException => StatusCodes.Status409Conflict,
                   
                    FishBreedingTypeMismatchException => StatusCodes.Status400BadRequest,
                    CannotDeleteOccupiedBreedingBoxException => StatusCodes.Status409Conflict,
                   
                    FishAlreadyInBreedingBoxException => StatusCodes.Status409Conflict,


                    // ===== Validation / Infrastructure ===== //
                    ArgumentNullException => StatusCodes.Status400BadRequest,


                    // ===== Fallback ===== //
                    _ => StatusCodes.Status500InternalServerError,  
                };

                context.Response.StatusCode = statusCode;

                ErrorResponseDto errorRespinse = new ErrorResponseDto
                {
                    StatusCode = statusCode,
                    Error = ex.GetType().Name,
                    Message = ex.Message
                };

                string json = JsonSerializer.Serialize(errorRespinse);
                await context.Response.WriteAsync(json);

            }
        }
    }
}
