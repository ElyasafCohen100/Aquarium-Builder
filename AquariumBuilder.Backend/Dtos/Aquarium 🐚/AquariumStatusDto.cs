using AquariumBuilder.Backend.Enums;

namespace AquariumBuilder.Backend.Dtos.Aquarium
{
    public class AquariumStatusDto
    {
        public bool IsReady { get; set; }
        public int FishCount { get; set; }
       
        public double WaterTemperature { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public int DecorationsCount { get; set; }
      
        public List<string> Warnings { get; set; } = new();
        public List<string> Recommendations { get; set; } = new();

        public AquariumOverallStatusEnum OverallStatus { get; set; }
    }
}
