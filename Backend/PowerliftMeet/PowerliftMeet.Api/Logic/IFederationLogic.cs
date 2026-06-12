using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IFederationLogic
{
    Task<IEnumerable<FederationDto>> GetFederationsAsync();
}
