using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.Configuration;

public class PositionConfiguration : AbstractConfiguration<Position>, IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        base.BaseConfigure(builder);

        builder.Property(x => x.Name).HasMaxLength(30);
    }
}