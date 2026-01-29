namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class BreedingBoxNotFoundException : Exception
    {
        public Guid BreedingBoxId { get; }

        public BreedingBoxNotFoundException(Guid breedingBoxId): base($"Breeding box with id '{breedingBoxId}' was not found.")
        {
            this.BreedingBoxId = breedingBoxId;
        }
    }
}