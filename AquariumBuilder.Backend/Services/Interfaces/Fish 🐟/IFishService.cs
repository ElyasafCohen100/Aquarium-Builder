using AquariumBuilder.Backend.Dtos.Fish;

namespace AquariumBuilder.Backend.Services.Interfaces
{
    public interface IFishService
    {
        public List<FishDto> GetAllFish();
        public FishDto? GetFishById(int id);
        public bool DeleteFishById(int id);
        public void CreateFish(CreateFishDto createFishDto);
        public void UpdateFish(int id, UpdateFishDto updateFishDto);
    }
}