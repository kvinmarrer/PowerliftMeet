namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;

public class LiftCard
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MeetAthleteId { get; set; }
    public MeetAthlete MeetAthlete { get; set; } = null!;
}