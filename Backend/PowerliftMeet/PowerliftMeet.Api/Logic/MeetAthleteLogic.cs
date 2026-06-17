using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database;
using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Api.Extensions;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Api.Logic;

public class MeetAthleteLogic : IMeetAthleteLogic
{
    private readonly AppDbContext _dbContext;

    public MeetAthleteLogic(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<MeetAthleteDto>> GetMeetAthletesAsync()
    {
        return await _dbContext.MeetAthletes
            .Include(ma => ma.Athlete)
                .ThenInclude(a => a.Club)
            .Include(ma => ma.Meet)
            .Include(ma => ma.WeightClass)
            .Select(ma => ma.ToDto())
            .ToListAsync();
    }

    public async Task<IEnumerable<MeetAthleteDto>> GetMeetAthletesByMeetIdAsync(Guid meetId)
    {
        return await _dbContext.MeetAthletes
            .Where(ma => ma.MeetId == meetId)
            .Include(ma => ma.Athlete)
                .ThenInclude(a => a.Club)
            .Include(ma => ma.Meet)
            .Include(ma => ma.WeightClass)
            .Select(ma => ma.ToDto())
            .ToListAsync();
    }

    public async Task<MeetAthleteDto> AddMeetAthleteToMeetAsync(Guid meetId, CreateMeetAthleteRequestDto request)
    {
        var meetAthlete = new MeetAthlete
        {
            MeetId = meetId,
            AthleteId = request.AthleteId,
            WeightClassId = request.WeightClassId
        };

        _dbContext.MeetAthletes.Add(meetAthlete);
        await _dbContext.SaveChangesAsync();

        var createdMeetAthlete = await _dbContext.MeetAthletes
            .Include(ma => ma.Athlete)
                .ThenInclude(a => a.Club)
            .Include(ma => ma.Meet)
            .Include(ma => ma.WeightClass)
            .FirstAsync(ma => ma.Id == meetAthlete.Id);

        return createdMeetAthlete.ToDto();
    }

    public async Task DeleteMeetAthleteAsync(Guid meetAthleteId)
    {
        var meetAthlete = await _dbContext.MeetAthletes.FindAsync(meetAthleteId);
        if (meetAthlete == null)
        {
            throw new KeyNotFoundException($"MeetAthlete with ID {meetAthleteId} not found.");
        }

        _dbContext.MeetAthletes.Remove(meetAthlete);
        await _dbContext.SaveChangesAsync();
    }
}