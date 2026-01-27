using AquariumBuilder.Backend.Dtos.Fish;
using AquariumBuilder.Backend.Exceptions.Fish;
using AquariumBuilder.Backend.Services.Interfaces;


namespace AquariumBuilder.Backend.Services.Fish
{
    public class FishService : IFishService
    {
        private static readonly List<FishDto> _fishList = new List<FishDto>();

        public List<FishDto> GetAllFish()
        {
            return _fishList;
        }

        public FishDto GetFishById(Guid fishId)
        {
            FishDto? fish = _fishList.FirstOrDefault(f => f.Id == fishId);
            
            if (fish == null)
            {
                throw new FishNotFoundException(fishId);
            }
            return fish;
        }

        public void CreateFish(CreateFishDto createFishDto)
        {
            FishDto newFish = new FishDto
            {
                Name = createFishDto.Name,
                Species = createFishDto.Species,
            };

            _fishList.Add(newFish);
        }

        public void UpdateFish(Guid fishId, UpdateFishDto updateFishDto)
        {
            FishDto fishToUpdate = GetFishById(fishId);

            fishToUpdate.IsAlive = updateFishDto.IsAlive;
            fishToUpdate.AgeInDays = updateFishDto.AgeInDays;
            fishToUpdate.HealthStatus = updateFishDto.HealthStatus;
        }

        public void DeleteFishById(Guid fishId)
        {
            FishDto fishToDelete = GetFishById(fishId);
            _fishList.Remove(fishToDelete);
        }
    }
}
