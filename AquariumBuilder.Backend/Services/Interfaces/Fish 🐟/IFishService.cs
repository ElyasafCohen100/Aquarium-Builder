using AquariumBuilder.Backend.Dtos.Fish;

namespace AquariumBuilder.Backend.Services.Interfaces
{
    public interface IFishService
    {
        public List<FishDto> GetAllFish();
        public FishDto? GetFishById(Guid fishId);
        public void DeleteFishById(Guid fishId);
        public void CreateFish(CreateFishDto createFishDto);
        public void UpdateFish(Guid fishId, UpdateFishDto updateFishDto);
    }
}