using AquariumBuilder.Backend.Dtos.Fish;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Exceptions.Fish;
using AquariumBuilder.Backend.Services.Interfaces;


namespace AquariumBuilder.Backend.Services.Fish
{
    public class FishService : IFishService
    {
        public static readonly List<FishDto> _fishList = new List<FishDto>();

        
        public List<FishDto> GetAllFish()
        {
            return _fishList;
        }

        public FishDto GetFishById(Guid fishId)
        {
            FishDto? fish = _fishList.FirstOrDefault(f => f.Id == fishId)
                 ?? throw new FishNotFoundException(fishId);

            return fish;
        }

        public FishModel GetFishModelById(Guid fishId)
        {
            FishDto? fishDto = _fishList.FirstOrDefault(f => f.Id == fishId)
                ?? throw new FishNotFoundException(fishId);

            return new FishModel
            {
                Id = fishDto.Id,
                ReproductionType = fishDto.ReproductionType
            };
        }

        public void CreateFish(CreateFishDto createFishDto)
        {
            FishDto newFish = new FishDto
            {
                Id = Guid.NewGuid(),
                Name = createFishDto.Name,
                Species = createFishDto.Species,
                ReproductionType = createFishDto.ReproductionType
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
