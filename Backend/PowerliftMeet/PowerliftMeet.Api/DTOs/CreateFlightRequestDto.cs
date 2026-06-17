namespace PowerliftMeet.Api.DTOs;

public class CreateFlightRequestDto
{
    public string Label { get; set; } = string.Empty;
    public int FlightNumber { get; set; }
    public List<Guid> MeetAthleteIds { get; set; } = new List<Guid>();
}