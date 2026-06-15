namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

public class Attempt
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey("LiftCard")]
    public Guid LiftCardId { get; set; }
    public LiftCard LiftCard { get; set; } = null!;
    public int LiftType { get; set; }
    public int Weight { get; set; }
    public string Result { get; set; } = null!;
}