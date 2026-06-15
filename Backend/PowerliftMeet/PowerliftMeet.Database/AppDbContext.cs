using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Meet> Meets { get; set; } = null!;
    public DbSet<Athlete> Athletes { get; set; } = null!;
    public DbSet<Club> Clubs { get; set; } = null!;
    public DbSet<WeightClass> WeightClasses { get; set; } = null!;
    public DbSet<Gender> Genders { get; set; } = null!;
    public DbSet<MeetAthlete> MeetAthletes { get; set; } = null!;
    public DbSet<LiftCard> LiftCards { get; set; } = null!;
    public DbSet<Attempt> Attempts { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
}