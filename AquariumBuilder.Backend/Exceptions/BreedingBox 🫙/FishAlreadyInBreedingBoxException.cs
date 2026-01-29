namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class FishAlreadyInBreedingBoxException : Exception
    {
        public Guid FishId { get; }

        public FishAlreadyInBreedingBoxException(Guid fishId) 
            : base($"Fish with ID '{fishId}' is already in a breeding box.")
        {
            this.FishId = fishId;
        }
    }
}
