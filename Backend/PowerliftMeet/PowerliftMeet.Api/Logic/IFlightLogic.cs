using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IFlightLogic
{
    Task<IEnumerable<FlightDto>> GetFlightsByMeetIdAsync(Guid meetId);
    Task<FlightDto> AddFlightToMeetAsync(Guid meetId, CreateFlightRequestDto request);
    Task DeleteFlightAsync(Guid flightId);
}