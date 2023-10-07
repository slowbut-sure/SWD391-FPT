using Infrastructures;
using ManagerApartment.DependencyInjection;
using Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", false, true)
    .Build();

//appConfiguration
var appConfiguration = configuration.Get<AppConfiguration>();

builder.Services.RepositoryConfiguration(appConfiguration.DatabaseConnection, configuration, appConfiguration.AzureBlobStorage);
builder.Services.ManagerApartmentConfiguration(appConfiguration.JWTSecretKey);

builder.Services.AddSingleton(appConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
