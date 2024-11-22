using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicG.Application.Auth.Interactor;
using MusicG.Application.Auth.Mapper;
using MusicG.Domain.Auth.Repository;
using MusicG.Domain.Auth.Usecases;
using MusicG.Domain.User;
using MusicG.Domain.User.Repository;
using MusicG.Domain.User.Usecases;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.Mapper;
using MusicG.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
string? connectionString = builder.Configuration.GetConnectionString("MusicAppDb");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuer = true,
            ValidIssuer = config.GetSection("Auth:ISSUER").Value,
            ValidateAudience = true,
            ValidAudience = config.GetSection("Auth:AUDIENCE").Value,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AUTH:KEY").Value)),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<AppDatabaseContext>(options => {
    if (connectionString != null) 
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] { }}
    });
});

SetupApplicationDi.SetupDi(builder);
SetupInfrastructureDi.SetupDi(builder);
SetupDomainDi.SetupDi(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();



app.Run();