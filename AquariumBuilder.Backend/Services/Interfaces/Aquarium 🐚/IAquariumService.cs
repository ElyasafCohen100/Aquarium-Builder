using AquariumBuilder.Backend.Dtos.Aquarium;


namespace AquariumBuilder.Backend.Services.Interfaces
{
    public interface IAquariumService
    {
       public AquariumStatusDto GetStatus();
    }
}
