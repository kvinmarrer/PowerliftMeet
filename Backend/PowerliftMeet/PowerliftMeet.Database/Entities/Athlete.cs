namespace PowerliftMeet.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Athlete
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Federation")]
    public int FederationId { get; set; }
    public Federation Federation { get; set; } = null!;
    [ForeignKey("WeightClass")]
    public int WeightClassId { get; set; }
    public WeightClass WeightClass { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;

}