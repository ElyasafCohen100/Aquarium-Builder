using Microsoft.AspNetCore.Mvc;
using AquariumBuilder.Backend.Dtos.Aquarium;
using AquariumBuilder.Backend.Services.Interfaces;


namespace AquariumBuilder.Backend.Controllers.Aquarium
{
    [ApiController]
    [Route("api/[controller]")]
    public class AquariumController : ControllerBase
    {

        // === Dependency Injection === //
        private readonly IAquariumService _aquariumService;

        // ========== constructor ========== //
        public AquariumController(IAquariumService aquariumService)
        {
            _aquariumService = aquariumService;
        }


        // ================================= the Endpoints ================================= //

        [HttpGet("status")] // Descriptive (עסקי מרכזי endpoint) 
        public ActionResult<AquariumStatusDto> GetStatus()
        {
            AquariumStatusDto status = _aquariumService.GetStatus();

            //if (!status.IsReady)
            //{
            //    return StatusCode(StatusCodes.Status503ServiceUnavailable, status);
            //}
            return Ok(status);
        }

        [HttpGet("health")] // Infrastructure (עסקי תשתיתי endpoint) 
        public ActionResult<AquariumHealthDto> GetHealth()
        {
            AquariumStatusDto status = _aquariumService.GetStatus();
           
            return Ok(new AquariumHealthDto()
            {
                IsReady = status.IsReady,
                OverallStatus = status.OverallStatus
            });
        }

        [HttpGet("warnings")] // Informational (מידע endpoint) 
        public ActionResult<List<AquariumWarningsDto>> GetWarnings()
        {
            AquariumStatusDto status = _aquariumService.GetStatus();
            return Ok(new AquariumWarningsDto()
            {
                Count = status.Warnings.Count,
                Warnings = status.Warnings
            });
        }

        [HttpGet("recommendations")] // Informational (מידע endpoint) 
        public ActionResult<List<AquariumRecommendationsDto>> GetRecommendations()
        {
            AquariumStatusDto status= _aquariumService.GetStatus();
            return Ok(new AquariumWarningsDto()
            {
                Count = status.Recommendations.Count,
                Warnings = status.Recommendations
            });
                
        }

        [HttpGet("summary")]
        public ActionResult<AquariumSummaryDto> Getsummary()
        {
            AquariumStatusDto status = _aquariumService.GetStatus();
            return Ok(new AquariumSummaryDto()
            {
                OverallStatus = status.OverallStatus,
                StatusMessage = status.StatusMessage,
                WarningCount = status.Warnings.Count
            }); 
        }
    }
}
