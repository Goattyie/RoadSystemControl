using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RoadSystemControl.BLL;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.DAL;
using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Database;
using RoadSystemControl.Tools.MappingConfiguration;

var builder = WebApplication.CreateBuilder(args);

#region Automapper Profiles

builder.Services.AddAutoMapper(typeof(DtoModelMappingConfig));

#endregion

#region Repositories

builder.Services.AddScoped<ILocationRepository, LocationRepository>();

#endregion

#region Services

builder.Services.AddScoped<ILocationService, LocationService>();

#endregion

#region Database

builder.Services.AddDbContext<RscContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Swagger

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

#endregion

var app = builder.Build();

InitializeDatabase.Initialize(app);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});
app.MapControllers();

app.Run();