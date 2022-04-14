using Microsoft.EntityFrameworkCore;
using RoadSystemControl.Database.Configuration;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database;

public class RscContext : DbContext
{
    public RscContext(DbContextOptions<RscContext> options) : base(options) { }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Police> Polices { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new PoliceConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}