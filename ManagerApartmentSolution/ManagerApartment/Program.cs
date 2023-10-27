using Infrastructures;
using ManagerApartment.DependencyInjection;
using ManagerApartment.Models;
using Services;
using System.Configuration;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000") // Thay đổi địa chỉ frontend của bạn
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<CurrentUser>();

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", false, true)
    .Build();

//appConfiguration
var appConfiguration = configuration.GetSection("AppConfiguration").Get<AppConfiguration>();

builder.Services.RepositoryConfiguration(appConfiguration.DatabaseConnection, configuration, appConfiguration.AzureBlobStorage);
builder.Services.ManagerApartmentConfiguration(appConfiguration.JWTSecretKey);
//builder.Services.AddAuthentication(appConfiguration.JWTSecretKey);
//builder.Services.AddAuthorization();

builder.Services.AddSingleton(appConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();