using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

namespace PowerliftMeet.Api.Logic;

public class FederationLogic : IFederationLogic
{
    private readonly AppDbContext _dbContext;

    public FederationLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<FederationDto>> GetFederationsAsync()
    {
        var federations = await _dbContext.Federations
            .ToListAsync();
        return federations.Select(f => f.ToDto());
    }
}