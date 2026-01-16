using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Enums.Aquarium;


namespace AquariumBuilder.Backend.Models.Aquarium
{
    public class AquariumModel
    {
        public int DecorationsCount { get; set; }
        public bool IsFilterWorking { get; set; } 
      
        public bool HasBiologicalMedia { get; set; }
        public double WaterTemperature { get; set; }
       
        public AquariumWaterTypeEnum WaterType { get; set; }

        public int FishCount => FishesList.Count;
        public List<FishModel> FishesList { get; set; } = new List<FishModel>();
    }
}       