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
            Gender = athlete.Gender,
            ClubId = athlete.ClubId,
            ClubDto = athlete.Club.ToDto(),
            DateOfBirth = athlete.DateOfBirth,
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

    public static MeetByIdDto ToMeetByIdDto(this Meet meet)
    {
        return new MeetByIdDto
        {
            Id = meet.Id,
            Name = meet.Name,
            Date = meet.Date,
            Location = meet.Location,
            Description = meet.Description,
            Status = meet.Status,
            MeetAthletes = meet.MeetAthletes?.Select(ma => ma.ToDto()) ?? new List<MeetAthleteDto>(),
            Flights = meet.Flights?.Select(f => f.ToDto()) ?? new List<FlightDto>()
        };
    }

    public static MeetAthleteDto ToDto(this MeetAthlete meetAthlete)
    {
        return new MeetAthleteDto
        {
            Id = meetAthlete.Id,
            MeetId = meetAthlete.MeetId,
            MeetDto = meetAthlete.Meet.ToDto(),
            AthleteId = meetAthlete.AthleteId,
            AthleteDto = meetAthlete.Athlete.ToDto(),
            WeightClassId = meetAthlete.WeightClassId,
            WeightClassDto = meetAthlete.WeightClass.ToDto(),
            BodyWeight = meetAthlete.BodyWeight,
            Lot = meetAthlete.Lot,
        };
    }

    public static FlightDto ToDto(this Flight flight)
    {
        return new FlightDto
        {
            Id = flight.Id,
            MeetId = flight.MeetId,
            FlightNumber = flight.FlightNumber,
            Label = flight.Label,
            MeetAthletes = flight.MeetAthletes?.Select(ma => ma.ToDto()).ToList() ?? new List<MeetAthleteDto>()
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