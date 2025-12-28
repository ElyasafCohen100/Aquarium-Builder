using AquariumBuilder.Backend.Enums;

namespace AquariumBuilder.Backend.Models.Fish
{
    public class FishModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;

        public bool isAlive { get; set; }
        public int AgeInDays { get; set; }
        public int MinDecorationsRequired { get; set; }

        public FishHealthStatusEnum HealthStatus { get; set; }
    }
}
