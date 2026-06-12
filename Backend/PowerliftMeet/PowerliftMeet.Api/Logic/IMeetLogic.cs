using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IMeetLogic
{
    Task<IEnumerable<MeetDto>> GetMeetsAsync();
    Task<MeetDto> CreateMeetAsync(CreateMeetDto request);
}