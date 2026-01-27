    using AquariumBuilder.Backend.Enums.BreedingBox;

namespace AquariumBuilder.Backend.Models.BreedingBox
{
    public class BreedingBoxModel
    {
        public Guid Id { get; set; } 
        public Guid? FishId { get; set; } // foreign key for Fish in the BreedingBox

        public BreedingBoxSizeEnum Size { get; set; }
        public BreedingBoxStatusEnum Status { get; set; } // Free or Occupied

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
