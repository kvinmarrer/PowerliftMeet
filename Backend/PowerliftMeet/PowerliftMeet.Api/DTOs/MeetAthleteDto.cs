namespace PowerliftMeet.Api.DTOs;

public class MeetAthleteDto
{
    public Guid Id { get; set; }
    public Guid AthleteId { get; set; }
    public AthleteDto AthleteDto { get; set; } = null!;
    public Guid MeetId { get; set; }
    public MeetDto MeetDto { get; set; } = null!;
    public Guid WeightClassId { get; set; }
    public WeightClassDto WeightClassDto { get; set; } = null!;
    public decimal? BodyWeight { get; set; }
    public int? Lot { get; set; }
    public string? Equipment { get; set; }
}
