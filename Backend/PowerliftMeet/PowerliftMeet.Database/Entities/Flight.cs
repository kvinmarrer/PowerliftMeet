namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Flight
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey("Meet")]
    public Guid MeetId { get; set; }
    public Meet Meet { get; set; } = null!;
    public int FlightNumber { get; set; }
    public string Label { get; set; } = string.Empty;
    public List<MeetAthlete> MeetAthletes { get; set; } = new List<MeetAthlete>();
}