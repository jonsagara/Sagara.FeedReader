using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader;
using Sagara.FeedReader.ConsoleSample;
using Sagara.FeedReader.Extensions;
using Serilog;

// The initial "bootstrap" logger is able to log errors during start-up. It's completely replaced by the
//   logger configured in `UseSerilog()` in HostBuilderHelper, once configuration and dependency-injection
//   have both been set up successfully.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = new HostApplicationBuilder();
    builder.Services.AddFeedReaderServices();
    builder.UseSerilog();
    using var host = builder.Build();

    using var serviceScope = host.Services.CreateScope();
    var feedReaderSvc = serviceScope.ServiceProvider.GetRequiredService<FeedReader>();
    var logger = Log.Logger.ForContext<Program>();


    //
    // Main loop
    //

    const string prompt = "Please enter feed url or exit to stop the program:";
    Console.WriteLine(prompt);

    var keepGoing = true;

    while (keepGoing)
    {
        try
        {
            string url = Console.ReadLine() ?? string.Empty;
            if (url.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                keepGoing = false;
                break;
            }

            var feedUrlsFromPage = await feedReaderSvc.GetFeedUrlsFromPageAsync(url);

            string? feedUrl;
            if (feedUrlsFromPage.Count < 1)
            {
                feedUrl = url;
            }
            else if (feedUrlsFromPage.Count == 1)
            {
                feedUrl = feedUrlsFromPage.First().Url;
            }
            else if (feedUrlsFromPage.Count == 2)
            {
                // if 2 urls, then its usually a feed and a comments feed, so take the first per default
                feedUrl = feedUrlsFromPage.First().Url;
            }
            else
            {
                int i = 1;
                Console.WriteLine("Found multiple feed, please choose:");
                foreach (var feedUrlFromPage in feedUrlsFromPage)
                {
                    Console.WriteLine($"{i++} - {feedUrlFromPage.Title} - {feedUrlFromPage.Url}");
                }
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int index) || index < 1 || index > feedUrlsFromPage.Count)
                {
                    Console.WriteLine("Wrong input. Press key to exit");
                    Console.ReadKey();

                    keepGoing = false;
                    return 0;
                }

                feedUrl = feedUrlsFromPage.ElementAt(index).Url;
            }

            var feed = await feedReaderSvc.ReadAsync(feedUrl);

            foreach (var item in feed.Items)
            {
                Console.WriteLine($"[Item] {item.Title}");
                Console.WriteLine($"> Publish Date: {item.PublishingDate:yyyy-MM-dd HH:mm:ss zzzz}");
                Console.WriteLine($"> URL: {item.Link}");
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex, "An error occurred: {Message}", ex.Message);

            if (ex.InnerException is not null)
            {
                logger.Error(ex.InnerException, "Inner exception: {Message}", ex.InnerException.Message);
            }
        }
        finally
        {
            Console.WriteLine("================================================");

            if (keepGoing)
            {
                Console.WriteLine(prompt);
            }
        }
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
