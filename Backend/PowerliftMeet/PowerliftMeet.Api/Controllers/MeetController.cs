using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetController : ControllerBase
{

    private readonly ILogger<MeetController> _logger;
    private readonly AppDbContext _dbContext;

    public MeetController(ILogger<MeetController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Meet>>> GetMeets()
    {
        return Ok(await _dbContext.Meets.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Meet>> CreateMeet(Meet meet)
    {
        _dbContext.Meets.Add(meet);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMeets), new { id = meet.Id }, meet);
    }
}