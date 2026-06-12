using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

namespace PowerliftMeet.Api.Logic;

public class AthleteLogic : IAthleteLogic
{
    private readonly AppDbContext _dbContext;

    public AthleteLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<AthleteDto>> GetAthletesAsync()
    {
        var athletes = await _dbContext.Athletes
            .Include(a => a.WeightClass)
            .ToListAsync();
        return athletes.Select(e => e.ToDto());
    }
}