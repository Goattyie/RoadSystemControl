var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDb>()

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();