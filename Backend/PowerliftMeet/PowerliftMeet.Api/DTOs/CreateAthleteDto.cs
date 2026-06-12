namespace PowerliftMeet.Api.DTOs;

public class CreateAthleteDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid WeightClassId { get; set; }
    public Guid FederationId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
}