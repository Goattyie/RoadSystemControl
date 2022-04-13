using Microsoft.EntityFrameworkCore;
using RoadSystemControl.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RscContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(("DefaultConnection"))));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();