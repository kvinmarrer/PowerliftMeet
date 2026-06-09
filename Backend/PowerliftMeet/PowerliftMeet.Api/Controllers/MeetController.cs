using Microsoft.AspNetCore.Mvc;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetController : ControllerBase
{

    private readonly ILogger<MeetController> _logger; 

    public MeetController(ILogger<MeetController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetMeets()
    {
        // Placeholder for actual data retrieval logic
        var meets = new List<string> { "Meet 1", "Meet 2", "Meet 3" };
        return Ok(meets);
        
    }

}