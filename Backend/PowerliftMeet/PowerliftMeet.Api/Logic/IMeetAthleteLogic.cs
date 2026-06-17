using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IMeetAthleteLogic
{
    Task<IEnumerable<MeetAthleteDto>> GetMeetAthletesAsync();
    Task<IEnumerable<MeetAthleteDto>> GetMeetAthletesByMeetIdAsync(Guid meetId);
    Task<MeetAthleteDto> AddMeetAthleteToMeetAsync(Guid meetId, CreateMeetAthleteRequestDto request);
    Task DeleteMeetAthleteAsync(Guid meetAthleteId);

}