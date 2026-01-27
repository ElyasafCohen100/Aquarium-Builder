using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;


namespace AquariumBuilder.Backend.Services.Interfaces.BreedingBox
{
    public interface IBreedingBoxValidationService
    {
        public void ValidateCreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto);
        public void ValidateAddFishToBreedingBox(BreedingBoxModel breedingBoxModel, FishModel fishModel);
        public void ValidateRemoveFishFromBreedingBox(BreedingBoxModel breedingBoxModel);
    }
}
