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
    public DbSet<MeetAthlete> MeetAthletes { get; set; } = null!;
    public DbSet<LiftCard> LiftCards { get; set; } = null!;
    public DbSet<Attempt> Attempts { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed WeightClasses
        modelBuilder.Entity<WeightClass>().HasData(
            // Herren
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000001"), Weight = 59},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000002"), Weight = 66},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000003"), Weight = 74},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000004"), Weight = 83},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000005"), Weight = 93},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000006"), Weight = 105},
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0001-000000000007"), Weight = 120},
            // Damen
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000001"), Weight = 47 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000002"), Weight = 52 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000003"), Weight = 57 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000004"), Weight = 63 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000005"), Weight = 69 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000006"), Weight = 76 },
            new WeightClass { Id = Guid.Parse("00000000-0000-0000-0002-000000000007"), Weight = 84 }
        );

        modelBuilder.Entity<Club>().HasData(
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000001"), Name = "C.H. Châtelaine Section haltérophilie", Description = "GE" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000002"), Name = "Geneva Powerlifting", Description = "GE" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000003"), Name = "Powerlifting Verein Cross Arena Glarnerland", Description = "GL" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000004"), Name = "Barbell Club Landquart", Description = "GR" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000005"), Name = "Elemental Athletes", Description = "LU" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000006"), Name = "Schwerathletik Nordwest", Description = "SO" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000007"), Name = "CLHM Club lausannois d'haltérophilie et de musculation", Description = "VD" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000008"), Name = "Powerlifting Zug", Description = "ZG" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000009"), Name = "Crossfort Kraftsport", Description = "ZH" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000010"), Name = "Kraftdreikampf Klub der Sportfreunde", Description = "ZH" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000011"), Name = "Outcast Strength System", Description = "ZH" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000012"), Name = "Powerlifting Nordostschweiz", Description = "TG" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000013"), Name = "Barbarian Barbell Club", Description = "VD" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000014"), Name = "Bienna Powerlifting", Description = "BE" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000015"), Name = "One Rep Strength", Description = "ZH" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000016"), Name = "Neuchâtel Force", Description = "NE" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000017"), Name = "Beo Barbell Club", Description = "BE" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000018"), Name = "Powerlifting Lausanne", Description = "VD" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000019"), Name = "Atlas Gym", Description = "VD" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000020"), Name = "Powerlifting Winti", Description = "ZH" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000021"), Name = "Nordic Barbell Club", Description = "FR" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000022"), Name = "Ultima Club", Description = "VD" },
            new Club { Id = Guid.Parse("00000000-0000-0000-0003-000000000023"), Name = "Kraftdreikampfverein Basilea", Description = "BL" }
        );
    }
}