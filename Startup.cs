using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleUI
{
    public class Startup
    {
        public static IHost Start()
        {
            var builder = new ConfigurationBuilder();
            BuildAppSettingsConfig(builder);
            BuildLoggerConfig(builder);
            return CreateHostBuilder(); 

        }
        static void BuildAppSettingsConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings{Environment.GetEnvironmentVariable("Bank.Payment.Matching_Env") ?? "Production"}.Json", optional: true)
                .AddEnvironmentVariables();
        }
        static void BuildLoggerConfig(IConfigurationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            Log.Logger.Information("Application started");
        }

        static IHost CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddScoped<IGreetingService, GreetingService>();
                })
                .UseSerilog()
                .Build();

        }
    }
}
