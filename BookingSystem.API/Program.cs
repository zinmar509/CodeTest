using BookingSystem.API;
using BookingSystem.DAL;
using BookingSystem.DAL.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("CustomHeader", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Custom header for API requests",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CustomHeader"
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddAuthentication(
             options => options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
             .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
                 JwtBearerDefaults.AuthenticationScheme, options => { });
builder.Services.AddAuthorization();
builder.Services.AddDbContext<AppDb>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("defaultDatabase")
));
builder.Services.AddSingleton(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionStr = config.GetConnectionString("defaultDatabase");
    return new ConnectionFactory(connectionStr);
});
builder.Services.ConfigurServies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
