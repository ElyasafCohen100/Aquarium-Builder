using AquariumBuilder.Backend.Models.Fish;

namespace AquariumBuilder.Backend.Models.Aquarium
{
    public class AquariumModel
    {
        public int FishCount => FishesList.Count;
        public bool isFilterWorking { get; set; } 
        public int DecorationsCount { get; set; }
        public double WaterTemperature { get; set; }

        public List<FishModel> FishesList { get; set; } = new List<FishModel>();
    }
}   