using AquariumBuilder.Backend.Dtos.Fish;

namespace AquariumBuilder.Backend.Services.Interfaces
{
    public interface IFishService
    {
        public List<FishDto> GetAllFish();
        public FishDto? GetFishById(Guid id);
        public bool DeleteFishById(Guid id);
        public void CreateFish(CreateFishDto createFishDto);
        public void UpdateFish(Guid id, UpdateFishDto updateFishDto);
    }
}