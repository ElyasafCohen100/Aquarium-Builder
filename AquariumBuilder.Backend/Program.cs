
using System.Text.Json.Serialization;
using AquariumBuilder.Backend.Middleware;
using AquariumBuilder.Backend.Services.Fish;
using AquariumBuilder.Backend.Services.Aquarium;
using AquariumBuilder.Backend.Services.Decoration;
using AquariumBuilder.Backend.Services.Interfaces;
using AquariumBuilder.Backend.Services.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces.Aquarium;
using AquariumBuilder.Backend.Services.Interfaces.BreedingBox;


namespace AquariumBuilder.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ====== Add services to the container ====== //
            builder.Services.AddSwaggerGen();

            // ===== to enable enum as string in the json responses ===== //
            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                    new JsonStringEnumConverter()
                    );
                });

            // ====== for the controllers to work with the servers ====== //

            // === Dependency Injection === //
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddScoped<IFishService, FishService>();
            builder.Services.AddScoped<IAquariumService, AquariumService>();
            builder.Services.AddScoped<IDecorationService, DecorationService>();
            builder.Services.AddScoped<IBreedingBoxService, BreedingBoxService>();

            builder.Services.AddScoped<IAquariumValidationService, AquariumValidationService>();
            builder.Services.AddScoped<IBreedingBoxValidationService, BreedingBoxValidationService>();


            var app = builder.Build();

            // ========= Configure the HTTP request pipeline ========= //
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();
            app.MapControllers();
          
            app.Run();
        }
    }
}
