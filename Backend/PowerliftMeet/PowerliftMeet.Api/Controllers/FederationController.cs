using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FederationController : ControllerBase
{

    private readonly ILogger<FederationController> _logger; 
    private readonly IFederationLogic _federationLogic;

    public FederationController(ILogger<FederationController> logger, IFederationLogic federationLogic)
    {
        _logger = logger;
        _federationLogic = federationLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FederationDto>>> GetFederations()
    {
        try
        {
            var federations = await _federationLogic.GetFederationsAsync();
            return Ok(federations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching federations.");
            return StatusCode(500, "Internal server error");
        }
    }

}