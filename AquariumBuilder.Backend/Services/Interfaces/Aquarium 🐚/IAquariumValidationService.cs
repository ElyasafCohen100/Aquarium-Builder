using AquariumBuilder.Backend.Models.Fish;

namespace AquariumBuilder.Backend.Services.Interfaces.Aquarium
{
    public interface IAquariumValidationService
    {
        public bool IsDecorationsValidForFish(FishModel fishModel, int decorationsCount);
    }
}
