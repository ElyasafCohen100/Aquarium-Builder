namespace AquariumBuilder.Backend.Exceptions.BreedingBox
{
    public class FishBreedingTypeMismatchException : Exception
    {
        public Guid FishId { get; }

        public FishBreedingTypeMismatchException(Guid fishId): base($"Fish '{fishId}' breeding type doesn't match the breeding box requirements")
        {
            this.FishId = fishId;
        }
    }
}
