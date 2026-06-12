using Microsoft.AspNetCore.Mvc;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Logic;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthleteController : ControllerBase
{

    private readonly ILogger<AthleteController> _logger; 

    public AthleteController(ILogger<AthleteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AthleteDto>>> GetAthletes()
    {
        // Placeholder for actual data retrieval logic
        var athletes = new List<AthleteDto>
        {
            new AthleteDto { Id = 1, FirstName = "Kevin", LastName = "Marrer", WeightClass = 1, WeightClassDto = new WeightClassDto { Id = 1, WeightClass = 74 }, DateOfBirth = DateTime.Now, Gender = "Male" },
            new AthleteDto { Id = 2, FirstName = "John", LastName = "Pork", WeightClass = 2, WeightClassDto = new WeightClassDto { Id = 2, WeightClass = 63 }, DateOfBirth = DateTime.Now, Gender = "Female" },
            new AthleteDto { Id = 3, FirstName = "Tung", LastName = "Sahur", WeightClass = 3, WeightClassDto = new WeightClassDto { Id = 3, WeightClass = 83 }, DateOfBirth = DateTime.Now, Gender = "Male" }
        };
        
        return Ok(athletes);
        
    }

}