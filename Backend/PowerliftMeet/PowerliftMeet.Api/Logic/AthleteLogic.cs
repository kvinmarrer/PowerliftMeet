using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;
using PowerliftMeet.Database.Entities;

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
            .Include(a => a.Federation)
            .ToListAsync();
        return athletes.Select(e => e.ToDto());
    }

    public async Task<AthleteDto> AddAthleteAsync(CreateAthleteDto request)
    {
        var athlete = new Athlete
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            WeightClassId = request.WeightClassId,
            FederationId = request.FederationId,
            DateOfBirth = DateOnly.FromDateTime(request.DateOfBirth),
            Gender = request.Gender
        };
        _dbContext.Athletes.Add(athlete);
        await _dbContext.SaveChangesAsync();
        return athlete.ToDto();
    }
}