namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WeightClass
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Weight { get; set; }
    [ForeignKey("Gender")]
    public Guid GenderId { get; set; }
    public Gender Gender { get; set; } = null!;

}