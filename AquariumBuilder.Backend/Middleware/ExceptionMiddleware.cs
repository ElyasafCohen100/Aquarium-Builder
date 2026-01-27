using System.Net;
using System.Text.Json;
using AquariumBuilder.Backend.Dtos.Common;


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
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    ArgumentException => StatusCodes.Status400BadRequest,

                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                    NotImplementedException => StatusCodes.Status501NotImplemented,
                    _ => StatusCodes.Status500InternalServerError
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
