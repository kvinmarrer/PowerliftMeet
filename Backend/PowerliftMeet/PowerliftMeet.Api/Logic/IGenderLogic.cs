using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IGenderLogic
{
    Task<IEnumerable<GenderDto>> GetGendersAsync();
}
