using AquariumBuilder.Backend.Dtos.Decoration;


namespace AquariumBuilder.Backend.Services.Interfaces
{
    public interface IDecorationService
    {
        public List<DecorationDto> GetAllDecorations();
        public DecorationDto? GetDecorationById(int id);
        public bool DeleteDecorationById(int id);
        public void CreateDecoration(CreateDecorationDto createDecorationDto);
    }
}
