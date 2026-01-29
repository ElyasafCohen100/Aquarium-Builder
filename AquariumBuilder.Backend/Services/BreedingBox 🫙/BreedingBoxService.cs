using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Enums.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces;
using AquariumBuilder.Backend.Exceptions.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces.BreedingBox;


namespace AquariumBuilder.Backend.Services.BreedingBox;

public class BreedingBoxService : IBreedingBoxService
{
    // ======= Dependency Injection ======= //
    private readonly IFishService _fishService;
    private readonly IBreedingBoxValidationService _breedingBoxValidationService;

    private static readonly List<BreedingBoxModel> _breedingBoxes = new();


    // ======= Constructor ======= //
    public BreedingBoxService(IFishService fishService, IBreedingBoxValidationService breedingBoxValidationService)
    {
        this._fishService = fishService;
        this._breedingBoxValidationService = breedingBoxValidationService;
    }


    public List<BreedingBoxModel> GetAllBreedingBoxes()
    {
        return _breedingBoxes;
    }

    public List<BreedingBoxModel> GetAvailableBreedingBoxes()
    {
        return _breedingBoxes
            .Where(b => b.Status == BreedingBoxStatusEnum.Free)
            .ToList();
    }

    public List<BreedingBoxModel> GetOccupiedBreedingBoxes()
    {
        return _breedingBoxes
            .Where(b => b.Status == BreedingBoxStatusEnum.Occupied)
            .ToList();
    }


    public BreedingBoxModel GetBreedingBoxById(Guid breedingBoxId)
    {
        BreedingBoxModel breedingBox = _breedingBoxes.FirstOrDefault(b => b.Id == breedingBoxId)
            ?? throw new BreedingBoxNotFoundException(breedingBoxId);

        return breedingBox;
    }

    public BreedingBoxModel CreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto)
    {
        this._breedingBoxValidationService.ValidateCreateBreedingBox(createBreedingBoxDto);

        BreedingBoxModel breedingBox = new BreedingBoxModel
        {
            Id = Guid.NewGuid(),
            Size = createBreedingBoxDto.Size,
            Status = BreedingBoxStatusEnum.Free,
            FishId = null,
            StartDate = null,
            EndDate = null
        };

        _breedingBoxes.Add(breedingBox);

        return breedingBox;

    }

    public BreedingBoxModel AddFishToBreedingBox(Guid breedingBoxId, Guid fishId)
    {
        BreedingBoxModel breedingBox = _breedingBoxes.FirstOrDefault(b => b.Id == breedingBoxId)
            ?? throw new BreedingBoxNotFoundException(breedingBoxId);

        FishModel fish = _fishService.GetFishModelById(fishId);

        this._breedingBoxValidationService.ValidateAddFishToBreedingBox(breedingBox, fish);

        breedingBox.FishId = fish.Id;
        breedingBox.Status = BreedingBoxStatusEnum.Occupied;
        breedingBox.StartDate = DateTime.UtcNow;

        return breedingBox;
    }

    public BreedingBoxModel RemoveFishFromBreedingBox(Guid breedingBoxId)
    {
        BreedingBoxModel breedingBox = _breedingBoxes.FirstOrDefault(b => b.Id == breedingBoxId)
              ?? throw new BreedingBoxNotFoundException(breedingBoxId);

        this._breedingBoxValidationService.ValidateRemoveFishFromBreedingBox(breedingBox);

        breedingBox.FishId = null;
        breedingBox.Status = BreedingBoxStatusEnum.Free;
        breedingBox.EndDate = DateTime.UtcNow;

        return breedingBox;
    }


    public void DeleteBreedingBoxById(Guid breedingBoxId)
    {
        BreedingBoxModel breedingBox = _breedingBoxes.FirstOrDefault(b => b.Id == breedingBoxId)
            ?? throw new BreedingBoxNotFoundException(breedingBoxId);

        if (breedingBox.Status != BreedingBoxStatusEnum.Free || breedingBox.FishId != null)
        {
            throw new CannotDeleteOccupiedBreedingBoxException(breedingBoxId);
        }

        _breedingBoxes.Remove(breedingBox);
    }
}
