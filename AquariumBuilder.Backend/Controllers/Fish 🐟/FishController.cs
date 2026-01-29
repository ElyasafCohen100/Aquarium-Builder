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

        [HttpGet]
        public ActionResult<List<FishDto>> GetAllFish()
        {
            List<FishDto> fishList = this._fishService.GetAllFish();
            return Ok(fishList);
        }

        [HttpGet("{fishId}")] 
        public ActionResult<FishDto>GetFishById(Guid fishId)
        {
            FishDto? fishById = this._fishService.GetFishById(fishId);
            return Ok(fishById);
        }

        [HttpPost] 
        public IActionResult CreateFish([FromBody] CreateFishDto createFishDto)
        {
            this._fishService.CreateFish(createFishDto);
            return Ok(new { message = "Fish created successfully 🐠" });
        }

        [HttpPut("{fishId}")]
        public IActionResult UpdateFish(Guid fishId, [FromBody] UpdateFishDto updateFishDto)
        {
            this._fishService.UpdateFish(fishId, updateFishDto);
            return Ok(new { message = "Fish updated successfully 🐠" });
        }

        [HttpDelete("{fishId}")]
        public IActionResult DeleteFish(Guid fishId)
        {
             this._fishService.DeleteFishById(fishId);
            return Ok(new { message = "Fish deleted successfully 🐠" });
        }
    }
}
