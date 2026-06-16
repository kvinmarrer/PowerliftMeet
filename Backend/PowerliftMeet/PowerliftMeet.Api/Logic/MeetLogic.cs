using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Database.Entities;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;

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
        return await _dbContext.Meets.Select(m => m.ToDto()).ToListAsync();
    }

    public async Task<MeetByIdDto> GetMeetByIdAsync(Guid id)
    {
        var meet = await _dbContext.Meets
            .Include(m => m.MeetAthletes)
                .ThenInclude(ma => ma.Athlete)
            .Include(m => m.MeetAthletes)
                .ThenInclude(ma => ma.Athlete)
                    .ThenInclude(a => a.Club)         
            .Include(m => m.MeetAthletes)
                .ThenInclude(ma => ma.WeightClass)
            .Include(m => m.Flights)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (meet == null) throw new KeyNotFoundException($"Meet with ID {id} not found.");

        return meet.ToMeetByIdDto();
    }

    public async Task<MeetDto> CreateMeetAsync(CreateMeetDto request)
    {
        var meet = request.ToEntity();

        _dbContext.Meets.Add(meet);
        await _dbContext.SaveChangesAsync();

        return meet.ToDto();
    }

    public async Task<MeetDto> EditMeetAsync(Guid id, CreateMeetDto meet)
    {
        var existingMeet = await _dbContext.Meets.FindAsync(id);

        if (existingMeet == null)
        {
            throw new KeyNotFoundException($"Meet with ID {id} not found.");
        }

        existingMeet.Name = meet.Name;
        existingMeet.Location = meet.Location;
        existingMeet.Date = meet.Date;
        existingMeet.Description = meet.Description;

        await _dbContext.SaveChangesAsync();

        return existingMeet.ToDto();
    }

    public async Task DeleteMeetAsync(Guid id)
    {
        var meet = await _dbContext.Meets.FindAsync(id);
        if (meet == null)
        {
            throw new KeyNotFoundException($"Meet with ID {id} not found.");
        }

        _dbContext.Meets.Remove(meet);
        await _dbContext.SaveChangesAsync();
    }
}