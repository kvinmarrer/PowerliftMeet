using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeightClassController : ControllerBase
{

    private readonly ILogger<WeightClassController> _logger; 
    private readonly IWeightClassLogic _weightClassLogic;

    public WeightClassController(ILogger<WeightClassController> logger, IWeightClassLogic weightClassLogic)
    {
        _logger = logger;
        _weightClassLogic = weightClassLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeightClassDto>>> GetWeightClasses()
    {
        try
        {
            var weightClasses = await _weightClassLogic.GetWeightClassesAsync();
            return Ok(weightClasses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching weight classes.");
            return StatusCode(500, "Internal server error");
        }
    }

}