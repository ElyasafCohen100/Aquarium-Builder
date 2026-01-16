using AquariumBuilder.Backend.Enums;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.Aquarium;
using AquariumBuilder.Backend.Enums.Aquarium;
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
                IsFilterWorking = true,
                DecorationsCount = 3,
                HasBiologicalMedia = true,
                WaterType = AquariumWaterTypeEnum.FreshWater,

                FishesList = new List<FishModel>
                {
                    new FishModel
                    {
                        Name = "Nemo - Tetra 🐟 ",
                        IsSchoolingFish = true,
                        MinSchoolSize = 4,
                        MinDecorationsRequired = 1,
                        RequiredWaterType = AquariumWaterTypeEnum.FreshWater
                    },
                    new FishModel
                    {
                        Name = "Gil - Tetra 🐟 ",
                        IsSchoolingFish = true,
                        MinSchoolSize = 4,
                        RequiredWaterType = AquariumWaterTypeEnum.FreshWater,
                        MinDecorationsRequired = 1
                    },
                    new FishModel
                    {
                        Name = "Duggy - Guppy 🐠 ",
                        IsSchoolingFish = false,
                        MinDecorationsRequired = 1,
                        RequiredWaterType = AquariumWaterTypeEnum.SaltWater,
                    }
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

            // ==== check Water Temperature ==== //
            if (!isTemperatureOptimal)
            {
                warnings.Add("⛔Aquarium is not healthy⛔ - Water temperature is out of optimal range (24-28°C).🌡️😶 ");
                recommendations.Add("Adjust the water temperature to be within the optimal range of 24-28°C. ");
            }

            // ==== check Fish Count ==== //
            if (aquarium.FishCount == 0)
            {
                warnings.Add("No fish in the aquarium. ");
                recommendations.Add("Add fish to the aquarium to create a balanced ecosystem. ");
            }

            // ==== check Filter Working ==== //
            if (!aquarium.IsFilterWorking)
            {
                warnings.Add("⛔Aquarium is not healthy⛔ - the Filter is not working.🫧😶 ");
                recommendations.Add("Repair or replace the aquarium filter to ensure proper water circulation and cleanliness.💦🛠️ ");
            }

            // ==== check media for Bacteria (if aquarium.FishCount > 0)==== //
            if (!this._aquariumValidationService.HasBiologicalMedia(aquarium.FishCount, aquarium.HasBiologicalMedia))
            {
                warnings.Add("⛔Aquarium is not healthy⛔ - Missing biological media for the current fish population.🦠😶 ");
                recommendations.Add("Add biological media to the aquarium to support beneficial bacteria growth.➕🦠 ");
            }

            // ==== if there is fishes ==== //
            foreach (FishModel fish in aquarium.FishesList)
            {
                // ==== check the count of Decoration for the fish ==== //
                if (!this._aquariumValidationService.IsDecorationsValidForFish(fish, aquarium.DecorationsCount))
                {
                    warnings.Add($"⛔Aquarium is not healthy⛔ - Not enough decorations for fish named: '{fish.Name}'.🐟");
                    recommendations.Add($"Add more decorations to meet the needs of fish named: '{fish.Name}'.➕");
                }

                // ==== check Water Type Compatibility for the fish ==== //
                if (!this._aquariumValidationService.IsFishWaterTypeCompatible(aquarium.WaterType, fish.RequiredWaterType))
                {
                    warnings.Add($"⛔Aquarium is not healthy⛔ - Water type is not compatible for fish named: '{fish.Name}'.💧😶 ");
                    recommendations.Add($"Adjust the water type to be compatible with fish named: '{fish.Name}'.🔄💧 ");
                }

                // ==== check Schooling Fish Requirements ==== // 

                // Count how many fishes of the same schooling type are in the aquarium //
                int sameSchoolingFishCount = aquarium.FishesList.Count(f => f.Name == fish.Name);

                if (!this._aquariumValidationService.IsSchoolingFishCountValid(fish.IsSchoolingFish, sameSchoolingFishCount, fish.MinSchoolSize))
                {
                    warnings.Add($"⛔Aquarium is not healthy⛔ - Not enough schooling fish for fish named: '{fish.Name}'.🐟😶 ");
                    recommendations.Add($"Add more schooling fish to meet the minimum school size for fish named: '{fish.Name}'.➕🐟 ");
                }

            }

            // ==== Determine if Aquarium is Ready ==== //
            bool isAquariumReady = warnings.Count == 0;

            if (warnings.Count == 0)
            {
                statusMessage = "Aquarium is healthy and has optimal conditions 😎🐠";
            }
            else
            {
                statusMessage = "⚠️Aquarium has some issues that need attention.⚠️ - Please review the warnings and recommendations.🧾 ";
            }

            // ==== Determine Overall Status ==== //
            AquariumOverallStatusEnum overallStatus =
                    isAquariumReady ? AquariumOverallStatusEnum.Healthy :
                    warnings.Count == 1 ? AquariumOverallStatusEnum.Warning :
                    AquariumOverallStatusEnum.Critical;

            // ==== return AquariumStatusDto ==== //
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
