using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[Authorize]
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

    [HttpGet("{id}")]
    public async Task<ActionResult<MeetByIdDto>> GetMeetById(Guid id)
    {
        try
        {
            var meet = await _meetLogic.GetMeetByIdAsync(id);
            if (meet == null)
            {
                return NotFound();
            }
            return Ok(meet);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving meet");
            return StatusCode(500, "An error occurred while retrieving the meet.");
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

    [HttpPut("{id}")]
    public async Task<ActionResult<MeetDto>> EditMeet(Guid id, CreateMeetDto meet)  
    {
        try
        {
            if (meet == null)
            {
                return BadRequest("Meet data is required.");
            }

            var updatedMeet = await _meetLogic.EditMeetAsync(id, meet);
            return Ok(updatedMeet);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error editing meet");
            return StatusCode(500, "An error occurred while editing the meet.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMeet(Guid id)
    {
        try
        {
            await _meetLogic.DeleteMeetAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting meet");
            return StatusCode(500, "An error occurred while deleting the meet.");
        }
    }
}