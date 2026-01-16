
using System.Text.Json.Serialization;
using AquariumBuilder.Backend.Services.Fish;
using AquariumBuilder.Backend.Services.Aquarium;
using AquariumBuilder.Backend.Services.Interfaces;
using AquariumBuilder.Backend.Services.Decoration;
using AquariumBuilder.Backend.Services.Interfaces.Aquarium;

namespace AquariumBuilder.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
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
            builder.Services.AddScoped<IAquariumValidationService, AquariumValidationService>();


            var app = builder.Build();

            // ========= Configure the HTTP request pipeline ========= //
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
          
            app.Run();
        }
    }
}
