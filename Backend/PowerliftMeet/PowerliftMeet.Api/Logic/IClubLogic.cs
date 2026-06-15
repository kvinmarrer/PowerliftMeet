using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IClubLogic
{
    Task<IEnumerable<ClubDto>> GetClubsAsync();
}
