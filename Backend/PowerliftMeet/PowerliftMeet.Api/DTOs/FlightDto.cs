namespace PowerliftMeet.Api.DTOs;

public class FlightDto
{
    public Guid Id { get; set; }
    public Guid MeetId { get; set; }
    public int FlightNumber { get; set; }
    public string Label { get; set; } = string.Empty;
    public List<MeetAthleteDto> MeetAthletes { get; set; } = new List<MeetAthleteDto>();
}