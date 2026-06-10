using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetController : ControllerBase
{

    private readonly ILogger<MeetController> _logger;
    private readonly IMeetLogic _meetLogic;

    public MeetController(ILogger<MeetController> logger, IMeetLogic meetLogic)
    {
        _logger = logger;
        _meetLogic = meetLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeetDto>>> GetMeets()
    {
        try
        {
        var meets = await _meetLogic.GetMeetsAsync();
        return Ok(meets);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving meets");
            return StatusCode(500, "An error occurred while retrieving meets.");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreateMeetDto>> CreateMeet(CreateMeetDto meet)
    {
        try
        {
            if (meet == null)
            {
                return BadRequest("Meet data is required.");
            }

            var response = await _meetLogic.CreateMeetAsync(meet);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating meet");
            return StatusCode(500, "An error occurred while creating the meet.");
        }
    }
}