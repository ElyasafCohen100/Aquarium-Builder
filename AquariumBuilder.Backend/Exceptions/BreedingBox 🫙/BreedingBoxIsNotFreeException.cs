namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class BreedingBoxIsNotFreeException : Exception
    {
        public Guid BreedingBoxId { get; }

        public BreedingBoxIsNotFreeException(Guid breedingBoxId) : base($"Breeding box '{breedingBoxId}' is not free")
        {
            this.BreedingBoxId = breedingBoxId;
        }
    }
}
