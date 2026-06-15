namespace PowerliftMeet.Api.DTOs;

public class AthleteDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Guid ClubId { get; set; }
    public ClubDto ClubDto { get; set; } = null!;
    public Guid GenderId { get; set; }
    public GenderDto GenderDto { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}