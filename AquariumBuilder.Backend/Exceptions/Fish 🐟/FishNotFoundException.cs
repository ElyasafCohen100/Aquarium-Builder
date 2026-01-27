
namespace AquariumBuilder.Backend.Exceptions.Fish
{
    public class FishNotFoundException : Exception
    {
        public Guid FishID { get; }

        public FishNotFoundException(Guid fishId) : base($"Fish with id '{fishId}' was not found")
        {
            this.FishID = fishId;
        }
    }
}
