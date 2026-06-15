namespace PowerliftMeet.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Athlete
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey("Club")]
    public Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;
    [ForeignKey("Gender")]
    public Guid GenderId { get; set; }
    public Gender Gender { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
}