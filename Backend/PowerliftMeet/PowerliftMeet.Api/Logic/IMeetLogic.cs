using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IMeetLogic
{
    Task<IEnumerable<MeetDto>> GetMeetsAsync();
    Task<MeetByIdDto> GetMeetByIdAsync(Guid id);
    Task<MeetDto> CreateMeetAsync(CreateMeetDto request);
    Task<MeetDto> EditMeetAsync(Guid id, CreateMeetDto meet);
    Task DeleteMeetAsync(Guid id);
}