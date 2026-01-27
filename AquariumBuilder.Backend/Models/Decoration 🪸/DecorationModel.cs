using AquariumBuilder.Backend.Enums.Decoration;

namespace AquariumBuilder.Backend.Models.Decoration
{
    public class DecorationModel
    {
        public int Id { get; set; }
        public String Name { get; set; } = string.Empty;
        public DecorationTypeEnum Type { get; set; }
        public bool IsSafeForFish { get; set; }
    }
}
