using AquariumBuilder.Backend.Enums;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.Aquarium;
using AquariumBuilder.Backend.Models.Aquarium;
using AquariumBuilder.Backend.Services.Interfaces;
using AquariumBuilder.Backend.Services.Interfaces.Aquarium;


namespace AquariumBuilder.Backend.Services.Aquarium
{
    public class AquariumService : IAquariumService
    {
        // In a real application, this method would retrieve data from a database or external source.//
        private AquariumModel GetAquariumModel()
        {
            return new AquariumModel()
            {
                WaterTemperature = 26.0,
                isFilterWorking = true,
                DecorationsCount = 3,

                FishesList = new List<FishModel>
                {
                    new FishModel {Name = "Nemo", MinDecorationsRequired = 2},
                    new FishModel {Name = "Duggy", MinDecorationsRequired = 4}
                }
            };
        }


        // === Dependency Injection === //
        private readonly IAquariumValidationService _aquariumValidationService;

        // ========== constructor ========== //

        public AquariumService(IAquariumValidationService aquariumValidationService)
        {
            this._aquariumValidationService = aquariumValidationService;
        }


        public AquariumStatusDto GetStatus()
        {
            AquariumModel aquarium = GetAquariumModel();

            // ==== fishes List & Decorations Count ==== //
            int decorationCount = aquarium.DecorationsCount;
           
            string statusMessage = string.Empty;
            List<string> warnings = new List<string>();
            List<string> recommendations = new List<string>();

            bool isTemperatureOptimal = aquarium.WaterTemperature >= 24.0 && aquarium.WaterTemperature <= 28.0;

            if (!isTemperatureOptimal)
            {
                warnings.Add("⛔Aquarium is not healthy⛔ - Water temperature is out of optimal range (24-28°C).🌡️😶 ");
                recommendations.Add("Adjust the water temperature to be within the optimal range of 24-28°C. ");
            }
            if (aquarium.FishCount == 0)
            {
                warnings.Add("No fish in the aquarium. ");
                recommendations.Add("Add fish to the aquarium to create a balanced ecosystem. ");
            }
            if (!aquarium.isFilterWorking)
            {
                warnings.Add("⛔Aquarium is not healthy⛔ - the Filter is not working.🫧😶 ");
                recommendations.Add("Repair or replace the aquarium filter to ensure proper water circulation and cleanliness.💦🛠️ ");
            }

            // ==== check the count of Decoration for the fish ==== //
            foreach (var fish in aquarium.FishesList)
            {
                bool isDecorationCountIsOk = this._aquariumValidationService.IsDecorationsValidForFish(fish, aquarium.DecorationsCount);

                if (!isDecorationCountIsOk)
                {
                    warnings.Add($"⛔Aquarium is not healthy⛔ - Not enough decorations for fish {fish.Name}.🐟");
                    recommendations.Add($"Add more decorations to meet the needs of fish {fish.Name}.➕");
                }
            }

            bool isAquariumReady = warnings.Count == 0;

            if (warnings.Count == 0)
            {
                statusMessage = "Aquarium is healthy and has optimal conditions 😎🐠";
            }
            else
            {
                statusMessage = "⚠️Aquarium has some issues that need attention.⚠️ - Please review the warnings and recommendations.🧾 ";
            }

            AquariumOverallStatusEnum overallStatus =
                    isAquariumReady ? AquariumOverallStatusEnum.Healthy :
                    warnings.Count == 1 ? AquariumOverallStatusEnum.Warning :
                    AquariumOverallStatusEnum.Critical;

            return new AquariumStatusDto()
            {
                Warnings = warnings,
                IsReady = isAquariumReady,
                StatusMessage = statusMessage,
                OverallStatus = overallStatus,
                FishCount = aquarium.FishCount,
                Recommendations = recommendations,
                WaterTemperature = aquarium.WaterTemperature,
                DecorationsCount = aquarium.DecorationsCount
            };
        }
    }
}
