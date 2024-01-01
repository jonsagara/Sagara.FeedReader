using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader.Extensions;
using Serilog;

namespace Sagara.FeedReader.ConsoleSample;

public static class HostBuilderHelper
{
    public static IHost BuildHost(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        return new HostBuilder()
            .ConfigureHostConfiguration(cb => ConfigureHost(cb, args))
            .ConfigureAppConfiguration((ctx, cb) => ConfigureApp(ctx, cb, args))
            .ConfigureServices(ConfigureServices)
            .UseConsoleLifetime()
            .UseSerilog(ConfigureSerilog)
            .Build();
    }


    //
    // Private methods
    //

    private static void ConfigureHost(IConfigurationBuilder configHost, string[] args)
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        configHost.AddJsonFile("hostsettings.json", optional: true);

        if (args is not null)
        {
            configHost.AddCommandLine(args);
        }
    }

    private static void ConfigureApp(HostBuilderContext context, IConfigurationBuilder configApp, string[] args)
    {
        Log.Logger.Information($"{nameof(HostBuilderHelper)} environment: {context.HostingEnvironment.EnvironmentName}");

        configApp
            .SetBasePath(context.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName.ToLower()}.json", optional: true);

        if (args is not null)
        {
            configApp.AddCommandLine(args);
        }

        configApp.AddEnvironmentVariables();
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddFeedReaderServices();
    }

    private static void ConfigureSerilog(HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfig)
    {
        // This is the .exe path in bin/{configuration}/{tfm}/
        var logDir = Directory.GetCurrentDirectory();

        // Log to the project directory.
        logDir = Path.Combine(logDir, @"..\..\..");
        logDir = Path.GetFullPath(logDir);
        Log.Logger.Information($"Logging directory: {logDir}");

        var logFilePathFormat = Path.Combine(logDir, "Logs", "log.txt");

        // Always write to a rolling file.
        loggerConfig
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.With<UtcTimestampEnricher>()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.File(logFilePathFormat, outputTemplate: "{UtcTimestamp:yyyy-MM-dd HH:mm:ss.fff} [{MachineName}] [{Level}] [{SourceContext:l}] {Message}{NewLine}{Exception}", rollingInterval: RollingInterval.Day);
    }
}
