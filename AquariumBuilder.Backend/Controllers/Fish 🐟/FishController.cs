using Microsoft.AspNetCore.Mvc;
using AquariumBuilder.Backend.Dtos.Fish;
using AquariumBuilder.Backend.Services.Interfaces;


namespace AquariumBuilder.Backend.Controllers.Fish
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishController : ControllerBase
    {
        // === Dependency Injection === //
        private readonly IFishService _fishService;

        // ========== constructor ========== //
        public FishController(IFishService ifishService)
        {
            this._fishService = ifishService;
        }

        // ================================= the Endpoints ================================= //

        [HttpGet] // to get all fish
        public ActionResult<List<FishDto>> GetAllFish()
        {
            List<FishDto> fishList = this._fishService.GetAllFish();
            return Ok(fishList);
        }

        [HttpGet("{id}")] // to get a fish by id
        public ActionResult<FishDto>GetFishById(Guid id)
        {
            FishDto? fishById = this._fishService.GetFishById(id);

            if(fishById== null)
            {
                return NotFound();
            }
            return Ok(fishById);
        }

        [HttpPost] // to buy a fish
        public IActionResult CreateFish([FromBody] CreateFishDto createFishDto)
        {
            this._fishService.CreateFish(createFishDto);
            return Ok(new { message = "Fish created successfully 🐠" });
        }

        [HttpPut("{id}")] // to update fish info
        public IActionResult UpdateFish(Guid id, [FromBody] UpdateFishDto updateFishDto)
        {
            this._fishService.UpdateFish(id, updateFishDto);
            //return NoContent();
            return Ok(new { message = "Fish updated successfully 🐠" });
        }

        [HttpDelete("{id}")] // to delete the fish
        public IActionResult DeleteFish(Guid id)
        {
            bool fishToDelete = this._fishService.DeleteFishById(id);

            if (!fishToDelete)
            {
                return NotFound();   
            }
            //return NoContent();
            return Ok(new { message = "Fish deleted successfully 🐠" });
        }
    }
}
