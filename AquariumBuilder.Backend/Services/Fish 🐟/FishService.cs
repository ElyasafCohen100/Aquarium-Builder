using System.Xml.Linq;
using AquariumBuilder.Backend.Enums;
using AquariumBuilder.Backend.Dtos.Fish;
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

        public FishDto GetFishById(int id)
        {
            return _fishList.FirstOrDefault(f => f.Id == id);
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

        public void UpdateFish(int id, UpdateFishDto updateFishDto)
        {
            FishDto? fishToUpdate = _fishList.FirstOrDefault(f => f.Id == id);  
               
            if(fishToUpdate == null)
            {
                return;
            }

            fishToUpdate.IsAlive = updateFishDto.IsAlive;
            fishToUpdate.AgeInDays = updateFishDto.AgeInDays;
            fishToUpdate.HealthStatus = updateFishDto.HealthStatus;
        }

        public bool DeleteFishById(int id)
        {
            FishDto? fishToDelete = _fishList.FirstOrDefault(f => f.Id == id);
            
            if(fishToDelete == null)
            {
                return false;
            }

            _fishList.Remove(fishToDelete);
            return true;
        }
    }
}
