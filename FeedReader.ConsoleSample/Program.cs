using FeedReader.ConsoleSample;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

// The initial "bootstrap" logger is able to log errors during start-up. It's completely replaced by the
//   logger configured in `UseSerilog()` in HostBuilderHelper, once configuration and dependency-injection
//   have both been set up successfully.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var host = HostBuilderHelper.BuildHost(args);

    using (var serviceScope = host.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;


    }

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}
