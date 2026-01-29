using Microsoft.AspNetCore.Mvc;
using AquariumBuilder.Backend.Dtos.BreedingBox;
using AquariumBuilder.Backend.Models.BreedingBox;
using AquariumBuilder.Backend.Services.Interfaces.BreedingBox;


namespace AquariumBuilder.Backend.Controllers.BreedingBox
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedingBoxController : ControllerBase
    {
        // === Dependency Injection === //
        private readonly IBreedingBoxService _breedingBoxService;

        // ========== constructor ========== //
        public BreedingBoxController(IBreedingBoxService breedingBoxService)
        {
            this._breedingBoxService = breedingBoxService;
        }

        // ================================= the Endpoints ================================= //
      
        [HttpPost]
        public ActionResult<BreedingBoxModel> CreateBreedingBox([FromBody] CreateBreedingBoxDto createBreedingBoxDto)
        {
            BreedingBoxModel newBreedingBox = this._breedingBoxService.CreateBreedingBox(createBreedingBoxDto);
            return Ok(newBreedingBox);
        }

        [HttpPost("{breedingBoxId}/add-fish")]
        public ActionResult<BreedingBoxModel> AddFishToBreedingBox(Guid breedingBoxId, [FromBody] AddFishToBreedingBoxDto dto)
        {
            BreedingBoxModel breedingBox = this._breedingBoxService.AddFishToBreedingBox(breedingBoxId, dto.FishId);
            return Ok(breedingBox);
        }

        [HttpPost("{breedingBoxId}/remove-fish")]
        public ActionResult<BreedingBoxModel> RemoveFishFromBreedingBox(Guid breedingBoxId)
        {
            BreedingBoxModel breedingBox = this._breedingBoxService.RemoveFishFromBreedingBox(breedingBoxId);
            return Ok(breedingBox);
        }
    }
}
