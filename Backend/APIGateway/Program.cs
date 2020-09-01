using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).WriteTo.Debug().WriteTo.Console().CreateLogger();
            try
            {
                Log.Information("Application start");
                var host = CreateHostBuilder(args).Build();// CreateHostBuilder(args).Build().Run();
                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ERPContext>();
                    context.Database.Migrate();
                }
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()                                   // Use serilog instead of default .NET logger
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
