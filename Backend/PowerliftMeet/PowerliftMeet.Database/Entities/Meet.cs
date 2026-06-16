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
    public string Status { get; set; } = "Scheduled";
    public List<MeetAthlete> MeetAthletes { get; set; } = new List<MeetAthlete>(); 
    public List<Flight> Flights { get; set; } = new List<Flight>();

}