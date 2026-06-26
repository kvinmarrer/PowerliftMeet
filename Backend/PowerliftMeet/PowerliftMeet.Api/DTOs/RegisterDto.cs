namespace PowerliftMeet.Api.DTOs;

public class RegisterDto
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
}