using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AquariumBuilder.Backend.Dtos.Decoration;
using AquariumBuilder.Backend.Services.Interfaces;

namespace AquariumBuilder.Backend.Controllers.Decoration
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecorationController : ControllerBase
    {
        // === Dependency Injection === //
        private readonly IDecorationService _decorationService;

        // ========== constructor ========== //
        public DecorationController(IDecorationService decorationService)
        {
            this._decorationService = decorationService;
        }

        // ================================= the Endpoints ================================= //

        [HttpGet]
        public ActionResult<List<DecorationDto>> GetAllDecorations()
        {
            List<DecorationDto> decorationsList = this._decorationService.GetAllDecorations();
            return Ok(decorationsList);
        }

        [HttpGet("{id}")]
        public ActionResult<DecorationDto> GetDecorationById(int id)
        {
            DecorationDto? decorationById = this._decorationService.GetDecorationById(id);

            if (decorationById == null) 
            {
                return NotFound();
            }
            return Ok(decorationById);
        }

        [HttpPost]
        public IActionResult CreateDecoration([FromBody] CreateDecorationDto createDecorationDto)
        {
            this._decorationService.CreateDecoration(createDecorationDto);
            //return NoContent();
            return Ok(new { message = "Decoration created successfully 🌿🪨🪸 " });
        }     

        [HttpDelete("{id}")]
        public IActionResult DeleteDecorationById(int id)
        {
            bool decorationToDelete = this._decorationService.DeleteDecorationById(id);
            if (!decorationToDelete)
            {
                return NotFound();
            }
            //return NoContent();
            return Ok(new { message = "decoration deleted successfully 🪸" });
        }
    }
}
