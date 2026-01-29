using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;


namespace AquariumBuilder.Backend.Services.Interfaces.BreedingBox
{
    public interface IBreedingBoxService
    {
        public List<BreedingBoxModel> GetAllBreedingBoxes();
        public List<BreedingBoxModel> GetAvailableBreedingBoxes();
        public List<BreedingBoxModel> GetOccupiedBreedingBoxes();

        public BreedingBoxModel GetBreedingBoxById(Guid BreedingBoxId);
        public BreedingBoxModel CreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto);
        public BreedingBoxModel AddFishToBreedingBox(Guid breedingBoxId, Guid fishId);
        public BreedingBoxModel RemoveFishFromBreedingBox(Guid breedingBoxId);

        public void DeleteBreedingBoxById(Guid breedingBoxId);
    }
}
