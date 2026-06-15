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
            .Include(a => a.Club)
            .ToListAsync();
        return athletes.Select(e => e.ToDto());
    }

    public async Task<AthleteDto> AddAthleteAsync(CreateAthleteDto request)
    {
        var athlete = new Athlete
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            WeightClassId = request.WeightClassId,
            ClubId = request.ClubId,
            DateOfBirth = DateOnly.FromDateTime(request.DateOfBirth),
            Gender = request.Gender
        };
        _dbContext.Athletes.Add(athlete);
        await _dbContext.SaveChangesAsync();

        var createdAthlete = await _dbContext.Athletes
            .Include(a => a.WeightClass)
            .Include(a => a.Club)
            .FirstAsync(a => a.Id == athlete.Id);

        return createdAthlete.ToDto();
    }

    public async Task<AthleteDto> EditAthleteAsync(Guid id, EditAthleteDto request)
    {
        
        var athlete = await _dbContext.Athletes
            .Include(a => a.WeightClass)
            .Include(a => a.Club)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (athlete == null)
        {
            throw new ArgumentException($"Athlete with ID {id} not found");
        }

        athlete.FirstName = request.FirstName;
        athlete.LastName = request.LastName;
        athlete.DateOfBirth = DateOnly.FromDateTime(request.DateOfBirth);
        athlete.Gender = request.Gender;
        athlete.ClubId = request.ClubId;
        athlete.WeightClassId = request.WeightClassId;

        await _dbContext.SaveChangesAsync();

        return await _dbContext.Athletes
            .Include(a => a.WeightClass)
            .Include(a => a.Club)
            .Where(a => a.Id == id)
            .Select(a => a.ToDto())
            .FirstAsync();
    }

    public async Task DeleteAthleteAsync(Guid id)
    {
        var athlete = await _dbContext.Athletes.FindAsync(id);

        if (athlete == null)
        {
            throw new ArgumentException($"Athlete with ID {id} not found");
        }

        _dbContext.Athletes.Remove(athlete);
        await _dbContext.SaveChangesAsync();
    }
}