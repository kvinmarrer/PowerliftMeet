using Microsoft.EntityFrameworkCore;
using PowerliftMeet.Database.Entities;

namespace PowerliftMeet.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Meet> Meets { get; set; } = null!;
}