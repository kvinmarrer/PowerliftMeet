using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Database.Entities;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

namespace PowerliftMeet.Api.Logic;

public class GenderLogic : IGenderLogic
{
    private readonly AppDbContext _dbContext;

    public GenderLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<GenderDto>> GetGendersAsync()
    {
        return _dbContext.Genders.Select(g => g.ToDto());
    }

}