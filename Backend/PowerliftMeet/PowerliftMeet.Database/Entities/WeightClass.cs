namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WeightClass
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Weight { get; set; }
    public bool IsMen { get; set; }
    public bool IsWomen { get; set; }
    public bool IsOther { get; set; }
}