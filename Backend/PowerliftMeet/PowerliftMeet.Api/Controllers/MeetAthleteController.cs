using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetAthleteController : ControllerBase
{

    private readonly ILogger<MeetAthleteController> _logger; 
    private readonly IMeetAthleteLogic _meetAthleteLogic;

    public MeetAthleteController(ILogger<MeetAthleteController> logger, IMeetAthleteLogic meetAthleteLogic)
    {
        _logger = logger;
        _meetAthleteLogic = meetAthleteLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeetAthleteDto>>> GetMeetAthletes()
    {
        try
        {
            var meetAthletes = await _meetAthleteLogic.GetMeetAthletesAsync();
            return Ok(meetAthletes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching meet athletes.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("meet/{meetId}")]
    public async Task<ActionResult<IEnumerable<MeetAthleteDto>>> GetMeetAthletesByMeetId(Guid meetId)
    {
        try
        {
            var meetAthletes = await _meetAthleteLogic.GetMeetAthletesByMeetIdAsync(meetId);
            return Ok(meetAthletes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching meet athletes by meet ID.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("meet/{meetId}")]
    public async Task<ActionResult<MeetAthleteDto>> AddMeetAthleteToMeet(Guid meetId, [FromBody] CreateMeetAthleteRequestDto request)
    {
        try
        {
            var meetAthlete = await _meetAthleteLogic.AddMeetAthleteToMeetAsync(meetId, request);
            return Ok(meetAthlete);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding meet athlete to meet.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{meetAthleteId}")]
    public async Task<ActionResult<MeetAthleteDto>> EditMeetAthlete(Guid meetAthleteId, [FromBody] EditMeetAthleteDto request)
    {
        try
        {
            var updatedMeetAthlete = await _meetAthleteLogic.EditMeetAthleteAsync(meetAthleteId, request);
            return Ok(updatedMeetAthlete);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating meet athlete.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{meetAthleteId}")]
    public async Task<IActionResult> DeleteMeetAthlete(Guid meetAthleteId)
    {
        try
        {
            await _meetAthleteLogic.DeleteMeetAthleteAsync(meetAthleteId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting meet athlete.");
            return StatusCode(500, "Internal server error");
        }
    }

}