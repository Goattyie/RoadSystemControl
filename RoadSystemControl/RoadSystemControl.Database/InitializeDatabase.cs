using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoadSystemControl.Database.InitializeTables;

namespace RoadSystemControl.Database;

public class InitializeDatabase
{
    public static void Initialize(IHost host)
    {
        var config = host.Services.GetRequiredService<IConfiguration>();
        var connectionString = config.GetConnectionString("DefaultConnection");
        var serviceCollection = new ServiceCollection();

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new NullReferenceException();
        }

        serviceCollection.AddDbContext<RscContext>(opt => opt.UseNpgsql(connectionString));

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<RscContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();
        
        CreateLocations.Init(dbContext);
        CreatePositions.Init(dbContext);
        CreateUsers.Init(dbContext);
    }
}