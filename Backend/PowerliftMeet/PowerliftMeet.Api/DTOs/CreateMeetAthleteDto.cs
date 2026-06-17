namespace PowerliftMeet.Api.DTOs;

public class CreateMeetAthleteRequestDto
{
    public Guid AthleteId { get; set; }
    public Guid WeightClassId { get; set; }

}