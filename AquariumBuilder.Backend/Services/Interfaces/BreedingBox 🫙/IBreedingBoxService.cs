using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;

namespace AquariumBuilder.Backend.Services.Interfaces.BreedingBox
{
    public interface IBreedingBoxService
    {
        public BreedingBoxModel CreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto);
        public BreedingBoxModel AddFishToBreedingBox(BreedingBoxModel breedingBoxModel, FishModel fishModel);
        public BreedingBoxModel RemoveFishFromBreedingBox(BreedingBoxModel breedingBoxModel);
    }
}
