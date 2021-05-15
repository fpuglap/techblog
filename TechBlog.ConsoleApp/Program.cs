using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using TechBlog.Application.Interfaces;
using TechBlog.Application.Services;
using TechBlog.ConsoleApp.Interfaces;
using TechBlog.ConsoleApp.Services;
using TechBlog.Domain.Interfaces;
using TechBlog.Domain.Models;
using TechBlog.Infrastructure.DataAccess;
using TechBlog.Infrastructure.Repositories;

namespace TechBlog.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting...\r\n");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IMongoDBDataAccess, MongoDBDataAccess>();
                    services.AddTransient<IRepository<Post>, PostRepository>();
                    services.AddTransient<IDataService, MockDataService>();
                    services.AddTransient<IData, DataService>();
                    services.AddSingleton<IApplication, Application>();

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                })
                .UseSerilog()
                .Build();

            var app = (IApplication)host.Services.GetService(typeof(IApplication));

            app.Run();

            // --------------------------------------------------------------------- //

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done Processing MongoDB");
            Console.ReadLine();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
