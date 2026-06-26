namespace PowerliftMeet.Database.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string? PasswordHash { get; set; } 
    public string? GoogleId { get; set; }    
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}