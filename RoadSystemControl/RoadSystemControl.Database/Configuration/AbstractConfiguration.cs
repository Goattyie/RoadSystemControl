using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.Configuration;

public class AbstractConfiguration<TModel> where TModel : BaseModel
{
    protected virtual void BaseConfigure(EntityTypeBuilder<TModel> builder)
    {
        builder.HasKey(x => x.Id);
    }
}