namespace PowerliftMeet.Api.DTOs;

public class CreateAthleteDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid ClubId { get; set; }
    public Guid GenderId { get; set; }
    public DateOnly DateOfBirth { get; set; }
}