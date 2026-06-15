using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

namespace PowerliftMeet.Api.Logic;

public class ClubLogic : IClubLogic
{
    private readonly AppDbContext _dbContext;

    public ClubLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<ClubDto>> GetClubsAsync()
    {
        return _dbContext.Clubs.Select(c => c.ToDto());
    }
}