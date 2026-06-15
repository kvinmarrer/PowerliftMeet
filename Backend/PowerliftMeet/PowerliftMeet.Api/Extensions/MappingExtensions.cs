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
            GenderId = athlete.GenderId,
            GenderDto = athlete.Gender.ToDto(),
            ClubId = athlete.ClubId,
            ClubDto = athlete.Club.ToDto(),
            DateOfBirth = athlete.DateOfBirth.ToDateTime(TimeOnly.MinValue),
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

    public static GenderDto ToDto(this Gender gender)
    {
        return new GenderDto
        {
            Id = gender.Id,
            Name = gender.Name
        };
    }

    public static WeightClassDto ToDto(this WeightClass weightClass)
    {
        return new WeightClassDto
        {
            Id = weightClass.Id,
            Weight = weightClass.Weight
        };
    }

    public static ClubDto ToDto(this Club club)
    {
        return new ClubDto
        {
            Id = club.Id,
            Name = club.Name,
            Description = club.Description
        };
    }

}