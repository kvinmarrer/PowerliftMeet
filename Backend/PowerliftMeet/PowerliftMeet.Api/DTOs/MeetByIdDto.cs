namespace PowerliftMeet.Api.DTOs;

public class MeetByIdDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Scheduled";
    public IEnumerable<MeetAthleteDto> MeetAthletes { get; set; } = new List<MeetAthleteDto>();
    public IEnumerable<FlightDto> Flights { get; set; } = new List<FlightDto>();
}