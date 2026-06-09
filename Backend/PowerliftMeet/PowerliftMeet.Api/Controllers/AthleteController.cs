using Microsoft.AspNetCore.Mvc;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthleteController : ControllerBase
{

    private readonly ILogger<AthleteController> _logger; 

    public AthleteController(ILogger<AthleteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAthletes()
    {
        // Placeholder for actual data retrieval logic
        var athletes = new List<string> { "Athlete 1", "Athlete 2", "Athlete 3" };
        return Ok(athletes);
        
    }

}