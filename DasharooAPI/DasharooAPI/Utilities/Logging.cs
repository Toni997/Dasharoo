using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DasharooAPI.Utilities
{
    public static class Logging
    {
        public static void Initialize(IHostBuilder hostBuilder)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(
                path: @"C:\dasharoo_logs\log-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Information
            ).CreateLogger();

            try
            {
                Log.Information("Application is starting");
                hostBuilder.Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
