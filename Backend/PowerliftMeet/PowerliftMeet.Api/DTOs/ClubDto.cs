namespace PowerliftMeet.Api.DTOs;

public class ClubDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}