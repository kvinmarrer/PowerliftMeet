using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IMeetLogic
{
    Task<IEnumerable<MeetDto>> GetMeetsAsync();
    Task<CreateMeetDto> CreateMeetAsync(CreateMeetDto request);
}