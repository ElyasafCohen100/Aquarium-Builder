using AquariumBuilder.Backend.Enums.Fish;
using AquariumBuilder.Backend.Models.Fish;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Enums.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;
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
            if(!Enum.IsDefined(typeof(BreedingBoxSizeEnum), createBreedingBoxDto.Size))
            {
                throw new ArgumentException("Invalid breeding box size.");
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

            if (breedingBoxModel.Status != BreedingBoxStatusEnum.Free)
            {
                throw new InvalidOperationException("Breeding box is not free.");
            }

            if(fishModel.ReproductionType != FishReproductionTypeEnum.LiveBearer)
            {
              throw new InvalidOperationException("the Fish is not suitable for breeding box because the Fish is not a live beare.");
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
              throw new InvalidOperationException("Breeding box is already free.");
            }

            if (breedingBoxModel.FishId == null)
            {
                throw new InvalidOperationException("There is no fish to remove from breeding box");
            }
        }
    }
}
