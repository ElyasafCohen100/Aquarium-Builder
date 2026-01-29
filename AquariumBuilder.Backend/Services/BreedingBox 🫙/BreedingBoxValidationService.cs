using AquariumBuilder.Backend.Enums.Fish;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Enums.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;
using AquariumBuilder.Backend.Exceptions.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces.BreedingBox;


namespace AquariumBuilder.Backend.Services.BreedingBox
{
    public class BreedingBoxValidationService : IBreedingBoxValidationService
    {
        // ======= Create Breeding Box Validation ======= //
        public void ValidateCreateBreedingBox(CreateBreedingBoxDto createBreedingBoxDto)
        {
            if(createBreedingBoxDto == null)
            {
                throw new ArgumentNullException(nameof(createBreedingBoxDto));
            }
        }

        // ======= Add Fish To Breeding Box Validation ======= //
        public void ValidateAddFishToBreedingBox(BreedingBoxModel breedingBoxModel, FishModel fishModel)
        {
            if (breedingBoxModel == null)
            {
                throw new ArgumentNullException(nameof(breedingBoxModel));
            }

            if (fishModel == null)
            {
                throw new ArgumentNullException(nameof(fishModel));
            }

            if (breedingBoxModel.FishId == fishModel.Id)
            {
                throw new FishAlreadyInBreedingBoxException(fishModel.Id);
            }

            if (breedingBoxModel.Status != BreedingBoxStatusEnum.Free)
            {
                throw new BreedingBoxIsNotFreeException(breedingBoxModel.Id);
            }

            if(fishModel.ReproductionType != FishReproductionTypeEnum.LiveBearer)
            {
                throw new FishBreedingTypeMismatchException(fishModel.Id);
            }
        }   

        // ======= Remove Fish From Breeding Box Validation ======= //
        public void ValidateRemoveFishFromBreedingBox(BreedingBoxModel breedingBoxModel)
        {
            if(breedingBoxModel == null)
            {
                throw new ArgumentNullException(nameof(breedingBoxModel));
            }

            if(breedingBoxModel.Status != BreedingBoxStatusEnum.Occupied)
            {
                throw new BreedingBoxIsAlreadyFreeException(breedingBoxModel.Id);
            }

            if (breedingBoxModel.FishId == null)
            {
                throw new NoFishInBreedingBoxException(breedingBoxModel.Id);
            }
        }
    }
}
    