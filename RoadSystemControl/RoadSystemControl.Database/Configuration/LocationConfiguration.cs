using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.Configuration;

public class LocationConfiguration : AbstractConfiguration<Location>, IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        BaseConfigure(builder);
        
        builder.Property(x => x.Name)
            .HasMaxLength(40);
    }
}