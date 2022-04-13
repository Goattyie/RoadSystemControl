using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.Configuration;

public class PoliceConfiguration : AbstractConfiguration<Police>, IEntityTypeConfiguration<Police>
{
    public void Configure(EntityTypeBuilder<Police> builder)
    {
        BaseConfigure(builder);

        builder.Property(x => x.FirstPhone)
            .HasMaxLength(13);
        builder.Property(x => x.SecondPhone)
            .HasMaxLength(13);
    }
}