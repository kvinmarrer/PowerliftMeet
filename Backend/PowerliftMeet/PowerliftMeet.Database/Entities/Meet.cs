namespace PowerliftMeet.Database.Entities;

public class Meet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public string? Description { get; set; }

}