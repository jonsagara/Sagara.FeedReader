using Microsoft.Extensions.Hosting;
using Serilog;

namespace Sagara.FeedReader.ConsoleSample;

public static class HostBuilderHelper
{
    public static IHostApplicationBuilder UseSerilog(this IHostApplicationBuilder builder, bool preserveStaticLogger = false, bool writeToProviders = false)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddSerilog(
            configureLogger: (serviceProvider, loggerConfig) =>
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
                    .ReadFrom.Configuration(builder.Configuration)
                    .ReadFrom.Services(serviceProvider)
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.File(logFilePathFormat, outputTemplate: "{UtcTimestamp:yyyy-MM-dd HH:mm:ss.fff} [{MachineName}] [{Level}] [{SourceContext:l}] {Message}{NewLine}{Exception}", rollingInterval: RollingInterval.Day);
            },
            preserveStaticLogger: preserveStaticLogger,
            writeToProviders: writeToProviders
            );

        return builder;
    }
}
