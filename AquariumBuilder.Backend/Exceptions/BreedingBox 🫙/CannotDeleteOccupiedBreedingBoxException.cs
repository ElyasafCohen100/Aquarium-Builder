namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class CannotDeleteOccupiedBreedingBoxException : Exception
    {
        public Guid BreedingBoxId { get; }

        public CannotDeleteOccupiedBreedingBoxException(Guid breedingBoxId)
            : base($"Cannot delete Breeding Box with ID '{breedingBoxId}' because it is currently occupied.")
        {
            this.BreedingBoxId = breedingBoxId;
        }
    }
}
