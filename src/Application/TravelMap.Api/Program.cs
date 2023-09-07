using NLog.Web;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Console;
using Hangfire.Dashboard;
using System.Text.Json.Serialization;
using TravelMap.Core;
using TravelMap.Api.Filters;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

var services = builder.Services;

services.AddControllers()
        .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = new UnderLinePolicy();
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddLogging(config =>
{
    // clear out default configuration
    config.ClearProviders();
    config.AddConfiguration(configuration.GetSection("Logging"));

    if (env == "Development")
    {
        config.AddConsole();
    }
});

builder.Host.UseNLog();

//hangfire
services.AddHangfire(configuration =>
{
    var storageOptions = new MemoryStorageOptions()
    {
        FetchNextJobTimeout = TimeSpan.FromMinutes(60)
    };

    configuration.UseMemoryStorage(storageOptions)
    .UseConsole()
    .UseDashboardMetric(DashboardMetrics.EnqueuedAndQueueCount)
    .UseDashboardMetric(DashboardMetrics.ProcessingCount)
    .UseDashboardMetric(DashboardMetrics.FailedCount)
    .UseDashboardMetric(DashboardMetrics.SucceededCount);
});

services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard(
                   pathMatch: "/hangfire",
                   options: new DashboardOptions()
                   {
                       Authorization = new[] { new HangfireAuthorizationFilter() }
                   }
               );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHangfireDashboard();

app.Run();