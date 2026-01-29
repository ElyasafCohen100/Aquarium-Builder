using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;

namespace AquariumBuilder.Backend.Services.Interfaces.BreedingBox
{
    public interface IBreedingBoxService
    {
        public BreedingBoxModel CreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto);
        public BreedingBoxModel AddFishToBreedingBox(Guid breedingBoxId, Guid fishId);
        public BreedingBoxModel RemoveFishFromBreedingBox(Guid breedingBoxId);
    }
}
