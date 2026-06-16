namespace PowerliftMeet.Api.DTOs;

public class MeetAthleteDto
{
    public Guid Id { get; set; }
    public Guid AthleteId { get; set; }
    public AthleteDto Athlete { get; set; } = null!;
    public Guid MeetId { get; set; }
    public MeetDto Meet { get; set; } = null!;
    public Guid WeightClassId { get; set; }
    public WeightClassDto WeightClass { get; set; } = null!;
    public Guid? FlightId { get; set; }
    public FlightDto? Flight { get; set; }
    public decimal? BodyWeight { get; set; }
    public int? Lot { get; set; }
    public string? Equipment { get; set; }
}
