using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthleteController : ControllerBase
{

    private readonly ILogger<AthleteController> _logger; 
    private readonly IAthleteLogic _athleteLogic;

    public AthleteController(ILogger<AthleteController> logger, IAthleteLogic athleteLogic)
    {
        _logger = logger;
        _athleteLogic = athleteLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AthleteDto>>> GetAthletes()
    {
        try
        {
            var athletes = await _athleteLogic.GetAthletesAsync();
            return Ok(athletes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching athletes.");
            return StatusCode(500, "Internal server error");
        }
    }

}