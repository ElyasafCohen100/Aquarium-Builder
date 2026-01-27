using AquariumBuilder.Backend.Enums;
using AquariumBuilder.Backend.Enums.Aquarium;
using AquariumBuilder.Backend.Enums.Fish;

namespace AquariumBuilder.Backend.Dtos.Fish
{
    public class CreateFishDto
    {
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;

        public int MinDecorationsRequired { get; set; }

        public bool IsSchoolingFish { get; set; }
        public int MinSchoolSize { get; set; }

        public AquariumWaterTypeEnum RequiredWaterType { get; set; }
        public FishReproductionTypeEnum ReproductionType { get; set; }
    }
}
