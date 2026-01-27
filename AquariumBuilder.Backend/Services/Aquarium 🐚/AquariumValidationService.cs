using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Enums.Aquarium;
using AquariumBuilder.Backend.Services.Interfaces.Aquarium;


namespace AquariumBuilder.Backend.Services.Aquarium
{
    public class AquariumValidationService : IAquariumValidationService
    {

        public bool HasBiologicalMedia(int fishCount, bool hasBiologicalMedia)
        {
            if (fishCount > 0 && !hasBiologicalMedia)
            {
                return false;
            }
            return true;
        }

        public bool IsDecorationsValidForFish(FishModel fishModel, int decorationsCount)
        {
            if (fishModel == null)
            {
                return false;
            }
            return decorationsCount >= fishModel.MinDecorationsRequired;
        }

        public bool IsSchoolingFishCountValid(bool isSchoolFish, int currentCountSchoolFish, int minSchoolSize)
        {
            if (!isSchoolFish)
            {
                return true;
            }
            return currentCountSchoolFish >= minSchoolSize;

        }

        public bool IsFishWaterTypeCompatible(AquariumWaterTypeEnum aquariumWaterType, AquariumWaterTypeEnum fishRequiredWaterType)
        {
            return aquariumWaterType == fishRequiredWaterType;
        }
    }
}
