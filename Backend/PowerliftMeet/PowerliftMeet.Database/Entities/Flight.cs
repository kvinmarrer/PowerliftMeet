namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;

public class Flight
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MeetId { get; set; }
    public Meet Meet { get; set; } = null!;
    public int FlightNumber { get; set; }
}