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
}