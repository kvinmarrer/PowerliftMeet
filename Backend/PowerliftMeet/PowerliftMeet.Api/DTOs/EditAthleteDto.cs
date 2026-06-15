namespace PowerliftMeet.Api.DTOs;

public class EditAthleteDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid WeightClassId { get; set; }
    public Guid ClubId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
}