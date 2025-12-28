using System.Globalization;
using AquariumBuilder.Backend.Enums.Decoration;

namespace AquariumBuilder.Backend.Dtos.Decoration
{
    public class DecorationDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = string.Empty;
        public DecorationTypeEnum Type { get; set; }
        public bool IsSafeForFish { get; set; }
    }
}
