using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

namespace PowerliftMeet.Api.Logic;

public class WeightClassLogic : IWeightClassLogic
{
    private readonly AppDbContext _dbContext;

    public WeightClassLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<WeightClassDto>> GetWeightClassesAsync()
    {
        return _dbContext.WeightClasses.Select(w => w.ToDto());
    }

    public async Task<IEnumerable<WeightClassDto>> GetWeightClassesByAthleteGenderAsync(Guid athleteId)
    {
        var athlete = await _dbContext.Athletes.FindAsync(athleteId);
        if (athlete == null)
        {
            throw new ArgumentException($"Athlete with ID {athleteId} not found.");
        }

        return _dbContext.WeightClasses
            .Where(w => (athlete.Gender == "Male" && w.IsMen) ||
                        (athlete.Gender == "Female" && w.IsWomen) ||
                        (athlete.Gender == "Other" && w.IsOther))
            .Select(w => w.ToDto());
    }
}