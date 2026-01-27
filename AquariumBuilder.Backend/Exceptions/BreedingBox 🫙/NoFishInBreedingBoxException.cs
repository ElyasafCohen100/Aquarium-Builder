namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class NoFishInBreedingBoxException : Exception
    {
        public Guid BreedingBoxId { get; }

        public NoFishInBreedingBoxException(Guid breedingBoxId) : base($"There is no fish in breeding box '{breedingBoxId}'")
        {
            this.BreedingBoxId = breedingBoxId;
        }
    }
}