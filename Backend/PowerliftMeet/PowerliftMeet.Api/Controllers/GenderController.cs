using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenderController : ControllerBase
{

    private readonly ILogger<GenderController> _logger; 
    private readonly IGenderLogic _genderLogic;

    public GenderController(ILogger<GenderController> logger, IGenderLogic genderLogic)
    {
        _logger = logger;
        _genderLogic = genderLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenderDto>>> GetGenders()
    {
        try
        {
            var genders = await _genderLogic.GetGendersAsync();
            return Ok(genders);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching genders.");
            return StatusCode(500, "Internal server error");
        }
    }

}