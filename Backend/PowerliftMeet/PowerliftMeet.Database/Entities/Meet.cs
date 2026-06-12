namespace PowerliftMeet.Database.Entities;

public class Meet
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public string? Description { get; set; }

}