using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClubController : ControllerBase
{

    private readonly ILogger<ClubController> _logger; 
    private readonly IClubLogic _clubLogic;

    public ClubController(ILogger<ClubController> logger, IClubLogic clubLogic)
    {
        _logger = logger;
        _clubLogic = clubLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClubDto>>> GetClubs()
    {
        try
        {
            var clubs = await _clubLogic.GetClubsAsync();
            return Ok(clubs);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching clubs.");
            return StatusCode(500, "Internal server error");
        }
    }

}