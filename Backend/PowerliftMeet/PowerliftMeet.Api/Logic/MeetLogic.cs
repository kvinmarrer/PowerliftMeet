using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Database.Entities;
using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public class MeetLogic : IMeetLogic
{
    private readonly AppDbContext _dbContext;

    public MeetLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<MeetDto>> GetMeetsAsync()
    {
        return await _dbContext.Meets
            .Select(m => new MeetDto
            {
                Id = m.Id,
                Name = m.Name,
                Date = m.Date,
                Location = m.Location,
                Description = m.Description
            })
            .ToListAsync();
    }

    public async Task<CreateMeetDto> CreateMeetAsync(CreateMeetDto request)
    {
        var meet = new Meet
        {
            Name = request.Name,
            Date = request.Date,
            Location = request.Location,
            Description = request.Description
        };

        _dbContext.Meets.Add(meet);
        await _dbContext.SaveChangesAsync();

        return request;
    }
}