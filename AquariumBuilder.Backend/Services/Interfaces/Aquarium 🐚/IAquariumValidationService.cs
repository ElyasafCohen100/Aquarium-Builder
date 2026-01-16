using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Enums.Aquarium;


namespace AquariumBuilder.Backend.Services.Interfaces.Aquarium
{
    public interface IAquariumValidationService
    {
        public bool HasBiologicalMedia(int fishCount, bool hasBiologicalMedia);
        public bool IsDecorationsValidForFish(FishModel fishModel, int decorationsCount);
        public bool IsSchoolingFishCountValid(bool isSchoolFish, int currentCountSchoolFish, int minSchoolSize);
        public bool IsFishWaterTypeCompatible(AquariumWaterTypeEnum aquariumWaterType, AquariumWaterTypeEnum fishRequiredWaterType);
    }
}