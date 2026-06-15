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

    [HttpPost]
    public async Task<ActionResult<CreateAthleteDto>> AddAthlete(CreateAthleteDto request)
    {
        try
        {
            var athlete = await _athleteLogic.AddAthleteAsync(request);
            return CreatedAtAction(nameof(GetAthletes), new { id = athlete.Id }, athlete);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding athlete.");
            return StatusCode(500, "Internal server error");
        }
    }   

    [HttpPut("{id}")]
    public async Task<ActionResult<EditAthleteDto>> EditAthlete(Guid id, EditAthleteDto request)
    {
        try
        {
            var athlete = await _athleteLogic.EditAthleteAsync(id, request);
            return Ok(athlete);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error updating athlete with ID: {Id}", id);
            return StatusCode(500, "Internal server error");            
        }
    }

}