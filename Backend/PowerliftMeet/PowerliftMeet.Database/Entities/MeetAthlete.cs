namespace PowerliftMeet.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MeetAthlete
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey("WeightClass")]
    public Guid WeightClassId { get; set; }
    public WeightClass WeightClass { get; set; } = null!;
    [ForeignKey("Meet")]
    public Guid MeetId { get; set; }
    public Meet Meet { get; set; } = null!;
    [ForeignKey("Athlete")]
    public Guid AthleteId { get; set; }
    public Athlete Athlete { get; set; } = null!;
    [ForeignKey("Flight")]
    public Guid? FlightId { get; set; }         
    public Flight? Flight { get; set; }
    public decimal? BodyWeight { get; set; }    
    public int? Lot { get; set; }                
    public string? Equipment { get; set; } 
}