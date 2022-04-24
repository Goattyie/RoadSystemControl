using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RoadSystemControl.BLL;
using RoadSystemControl.BLL.Configuration;
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
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Services

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

#endregion

#region Database

builder.Services.AddDbContext<RscContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Swagger

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,

            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
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

app.UseAuthentication();
app.UseAuthorization();

app.Run();