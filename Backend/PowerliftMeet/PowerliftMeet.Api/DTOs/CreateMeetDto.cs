namespace PowerliftMeet.Api.DTOs;

public class CreateMeetDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Description { get; set; }
}