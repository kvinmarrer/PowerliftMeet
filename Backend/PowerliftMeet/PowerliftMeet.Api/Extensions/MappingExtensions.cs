using PowerliftMeet.Api.DTOs;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Api.Extensions;

public static class MappingExtensions
{
    public static AthleteDto ToDto(this Athlete athlete)
    {
        return new AthleteDto
        {
            Id = athlete.Id,
            FirstName = athlete.FirstName,
            LastName = athlete.LastName,
            WeightClass = athlete.WeightClassId,
            WeightClassDto = new WeightClassDto
            {
                Id = athlete.WeightClass.Id,
                Weight = athlete.WeightClass.Weight
            },
            DateOfBirth = athlete.DateOfBirth,
            Gender = athlete.Gender
        };
    }

    public static MeetDto ToDto(this Meet meet)
    {
        return new MeetDto
        {
            Id = meet.Id,
            Name = meet.Name,
            Date = meet.Date,
            Location = meet.Location,
            Description = meet.Description
        };
    }

    public static Meet ToEntity(this CreateMeetDto dto)
    {
        return new Meet
        {
            Name = dto.Name,
            Date = dto.Date,
            Location = dto.Location,
            Description = dto.Description
        };
    }
}