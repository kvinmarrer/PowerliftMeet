using PowerliftMeet.Api.DTOs;

namespace PowerliftMeet.Api.Logic;

public interface IWeightClassLogic
{
    Task<IEnumerable<WeightClassDto>> GetWeightClassesAsync();
}
