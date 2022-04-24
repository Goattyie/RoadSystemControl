using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.Configuration;

public class UserConfiguration : AbstractConfiguration<User>, IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        BaseConfigure(builder);

        builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Role).IsRequired();
    }
}