namespace PowerliftMeet.Api.DTOs;

public class AthleteDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int WeightClass { get; set; }
    public WeightClassDto WeightClassDto { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
}