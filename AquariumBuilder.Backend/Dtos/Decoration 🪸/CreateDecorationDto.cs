using AquariumBuilder.Backend.Enums.Decoration;

namespace AquariumBuilder.Backend.Dtos.Decoration
{
    public class CreateDecorationDto
    {
        public String Name { get; set; } = string.Empty;
        public DecorationTypeEnum Type { get; set; }
        public bool IsSafeForFish { get; set; }
    }
}
