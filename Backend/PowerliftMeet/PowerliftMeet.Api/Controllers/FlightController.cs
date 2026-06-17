using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{

    private readonly ILogger<FlightController> _logger; 
    private readonly IFlightLogic _flightLogic;

    public FlightController(ILogger<FlightController> logger, IFlightLogic flightLogic)
    {
        _logger = logger;
        _flightLogic = flightLogic;
    }

    [HttpGet("meet/{meetId}")]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlightsByMeetId(Guid meetId)
    {
        try
        {
            var flights = await _flightLogic.GetFlightsByMeetIdAsync(meetId);
            return Ok(flights);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching flights by meet ID.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("meet/{meetId}")]
    public async Task<ActionResult<FlightDto>> AddFlightToMeet(Guid meetId, [FromBody] CreateFlightRequestDto request)
    {
        try
        {
            var flight = await _flightLogic.AddFlightToMeetAsync(meetId, request);
            return Ok(flight);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding flight to meet.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{flightId}")]
    public async Task<IActionResult> DeleteFlight(Guid flightId)
    {
        try
        {
            await _flightLogic.DeleteFlightAsync(flightId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting flight.");
            return StatusCode(500, "Internal server error");
        }
    }

}