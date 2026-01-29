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

        [HttpGet]
        public ActionResult<List<BreedingBoxModel>> GetAllBreedingBoxes()
        {
            List<BreedingBoxModel> breedingBoxes = this._breedingBoxService.GetAllBreedingBoxes();
            return Ok(breedingBoxes);
        }

        [HttpGet("available")]
        public ActionResult<BreedingBoxModel> GetAvailableBreedingBoxes()
        {
            List<BreedingBoxModel> availableBreedingBoxes = this._breedingBoxService.GetAvailableBreedingBoxes();
            return Ok(availableBreedingBoxes);
        }

        [HttpGet("occupied")]
        public ActionResult<BreedingBoxModel> GetOccupiedBreedingBoxes()
        {
            List<BreedingBoxModel> occupiedBreedingBoxes = this._breedingBoxService.GetOccupiedBreedingBoxes();
            return Ok(occupiedBreedingBoxes);
        }

        [HttpGet("{breedingBoxId}")]
        public IActionResult GetBreedingBoxById(Guid breedingBoxId)
        {
            // this._breedingBoxService.GetBreedingBoxById(breedingBoxId);
            BreedingBoxModel breedingBox = this._breedingBoxService.GetBreedingBoxById(breedingBoxId);

            return Ok(breedingBox);
        }

       
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

        
        [HttpDelete("{breedingBoxId}")]
        public IActionResult DeleteBreedingBoxById(Guid breedingBoxId)
        {
            this._breedingBoxService.DeleteBreedingBoxById(breedingBoxId);
            //return NoContent();
            return Ok(new { message = "Breeding box deleted successfully 🦪" });
        }
    }
}
