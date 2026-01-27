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

        [HttpPost("add-fish")]
        public ActionResult<BreedingBoxModel> AddFishToBreedingBox([FromBody] AddFishToBreedingBoxDto dto)
        {
            BreedingBoxModel BreedingBoxAftrerAdding = this._breedingBoxService.AddFishToBreedingBox(dto.BreedingBox, dto.Fish);
            return Ok(BreedingBoxAftrerAdding);
        }

        [HttpPost("remove-fish")]
        public ActionResult<BreedingBoxModel> RemoveFishFromBreedingBox([FromBody] BreedingBoxModel breedingBoxModel)
        {
            BreedingBoxModel BreedingBoxAftrerRemoval = this._breedingBoxService.RemoveFishFromBreedingBox(breedingBoxModel);
            return Ok(BreedingBoxAftrerRemoval);
        }
    }
}
