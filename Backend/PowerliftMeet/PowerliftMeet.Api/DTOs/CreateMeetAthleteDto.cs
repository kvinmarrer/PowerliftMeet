namespace PowerliftMeet.Api.DTOs;

public class CreateMeetAthleteRequestDto
{
    public Guid AthleteId { get; set; }
    public Guid WeightClassId { get; set; }
    public string Equipment { get; set; } = string.Empty;
    public int Lot { get; set; }
    public decimal BodyWeight { get; set; }
}