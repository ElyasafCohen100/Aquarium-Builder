using AquariumBuilder.Backend.Dtos.Fish;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Services.Interfaces.Aquarium;

namespace AquariumBuilder.Backend.Services.Aquarium
{
    public class AquariumValidationService : IAquariumValidationService
    {

        public bool IsDecorationsValidForFish(FishModel fishModel, int decorationsCount)
        {
            if (fishModel == null)
            {
                return false;
            }
            return decorationsCount >= fishModel.MinDecorationsRequired;
        }
    }
}
