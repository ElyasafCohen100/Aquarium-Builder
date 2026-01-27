using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Enums.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces.BreedingBox;


namespace AquariumBuilder.Backend.Services.BreedingBox;

public class BreedingBoxService : IBreedingBoxService
{
    // ======= Dependency Injection ======= //
    private readonly IBreedingBoxValidationService _breedingBoxValidationService;


    // ======= Constructor ======= //
    public BreedingBoxService(IBreedingBoxValidationService breedingBoxValidationService)
    {
        this._breedingBoxValidationService = breedingBoxValidationService;
    }

   
    public BreedingBoxModel CreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto)
    {
        this._breedingBoxValidationService.ValidateCreateBreedingBox(createBreedingBoxDto);

        return new BreedingBoxModel
        {
            Id = Guid.NewGuid(),
            Size = createBreedingBoxDto.Size,
            Status = BreedingBoxStatusEnum.Free,
            FishId = null,
            StartDate = null,
            EndDate = null
        };
    }

    public BreedingBoxModel AddFishToBreedingBox(BreedingBoxModel breedingBoxModel, FishModel fishModel)
    {
        this._breedingBoxValidationService.ValidateAddFishToBreedingBox(breedingBoxModel, fishModel);

        breedingBoxModel.FishId = fishModel.Id;
        breedingBoxModel.Status = BreedingBoxStatusEnum.Occupied;
        breedingBoxModel.StartDate = DateTime.UtcNow;

        return breedingBoxModel;
    }

    public BreedingBoxModel RemoveFishFromBreedingBox(BreedingBoxModel breedingBoxModel)
    {
        this._breedingBoxValidationService.ValidateRemoveFishFromBreedingBox(breedingBoxModel);

        breedingBoxModel.FishId = null;
        breedingBoxModel.Status = BreedingBoxStatusEnum.Free;
        breedingBoxModel.EndDate = DateTime.UtcNow;
       
        return breedingBoxModel;
    }
}
