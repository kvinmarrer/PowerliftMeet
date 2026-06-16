namespace PowerliftMeet.Api.DTOs;

public class CreateAthleteDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid ClubId { get; set; }
    public string Gender { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
}