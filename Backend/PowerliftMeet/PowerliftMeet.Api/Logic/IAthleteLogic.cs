using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IAthleteLogic
{
    Task<IEnumerable<AthleteDto>> GetAthletesAsync();
    Task<AthleteDto> AddAthleteAsync(CreateAthleteDto request);
    Task<AthleteDto> EditAthleteAsync(Guid id, EditAthleteDto request);
}