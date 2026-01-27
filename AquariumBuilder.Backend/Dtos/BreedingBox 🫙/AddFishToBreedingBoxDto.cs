using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Models.BreedingBox;

namespace AquariumBuilder.Backend.Dtos.BreedingBox
{
    public class AddFishToBreedingBoxDto
    {
        public required BreedingBoxModel BreedingBox { get; set; }
        public required FishModel Fish { get; set; }
    }
}
