namespace PowerliftMeet.Api.DTOs;

public class AthleteDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid WeightClassId { get; set; }
    public WeightClassDto WeightClassDto { get; set; } = null!;
    public Guid ClubId { get; set; }
    public ClubDto ClubDto { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
}