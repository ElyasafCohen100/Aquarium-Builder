using AquariumBuilder.Backend.Dtos.Decoration;
using AquariumBuilder.Backend.Services.Interfaces;


namespace AquariumBuilder.Backend.Services.Decoration
{
    public class DecorationService : IDecorationService
    {
        private static readonly List<DecorationDto> _decorationsList = new List<DecorationDto>();

        private static int _nextId = 1;

        public List<DecorationDto> GetAllDecorations()
        {
            return _decorationsList;
        }

        public DecorationDto? GetDecorationById(int id)
        {
            return _decorationsList.FirstOrDefault(d => d.Id == id);
        }

        public void CreateDecoration(CreateDecorationDto createDecorationDto)
        {
            DecorationDto newDecoration = new DecorationDto
            {
                Id = _nextId++,
                Name = createDecorationDto.Name,
                Type = createDecorationDto.Type,
                IsSafeForFish = createDecorationDto.IsSafeForFish
            };

            _decorationsList.Add(newDecoration);
        }

        public bool DeleteDecorationById(int id)
        {
            DecorationDto? decorationToDelete = _decorationsList.FirstOrDefault(d => d.Id == id);

            if (decorationToDelete == null)
            {
                return false;
            }
            _decorationsList.Remove(decorationToDelete);
            return true;
        }
    }
}
