using AquariumBuilder.Backend.Enums;

namespace AquariumBuilder.Backend.Dtos.Fish
{
    public class UpdateFishDto
    {
        public bool IsAlive { get; set; }
        public int AgeInDays { get; set; }

        public FishHealthStatusEnum HealthStatus { get; set; }
    }
}