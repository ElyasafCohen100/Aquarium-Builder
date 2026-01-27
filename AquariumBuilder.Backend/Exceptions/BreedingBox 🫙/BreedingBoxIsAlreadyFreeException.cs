namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class BreedingBoxIsAlreadyFreeException : Exception
    {
        public Guid BreedingBoxId { get; }

        public BreedingBoxIsAlreadyFreeException(Guid breedingBoxId): base($"Breeding box '{breedingBoxId}' is already free")
        {
            this.BreedingBoxId = breedingBoxId;
        }
    }
}
