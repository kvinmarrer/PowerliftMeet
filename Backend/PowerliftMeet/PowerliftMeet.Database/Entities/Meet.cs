namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;

public class Meet
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string Location { get; set; } = null!;
    public string? Description { get; set; }

}