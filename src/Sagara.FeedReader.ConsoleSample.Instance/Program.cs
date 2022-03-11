using Microsoft.Extensions.DependencyInjection;
using Sagara.FeedReader;
using Sagara.FeedReader.ConsoleSample.Instance;
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
        var feedReaderSvc = services.GetRequiredService<FeedReaderService>();


        //
        // Main loop
        //

        const string prompt = "Please enter feed url or exit to stop the program:";
        Console.WriteLine(prompt);

        while (true)
        {
            try
            {
                string url = Console.ReadLine() ?? string.Empty;
                if (url.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                var urls = await feedReaderSvc.GetFeedUrlsFromPageAsync(url);

                string? feedUrl;
                if (urls is null || urls.Count < 1)
                {
                    feedUrl = url;
                }
                else if (urls.Count == 1)
                {
                    feedUrl = urls.First().Url;
                }
                else if (urls.Count == 2)
                {
                    // if 2 urls, then its usually a feed and a comments feed, so take the first per default
                    feedUrl = urls.First().Url;
                }
                else
                {
                    int i = 1;
                    Console.WriteLine("Found multiple feed, please choose:");
                    foreach (var feedurl in urls)
                    {
                        Console.WriteLine($"{i++} - {feedurl.Title} - {feedurl.Url}");
                    }
                    var input = Console.ReadLine();

                    if (!int.TryParse(input, out int index) || index < 1 || index > urls.Count)
                    {
                        Console.WriteLine("Wrong input. Press key to exit");
                        Console.ReadKey();
                        return 0;
                    }

                    feedUrl = urls.ElementAt(index).Url;
                }

                var feed = await feedReaderSvc.ReadAsync(feedUrl);

                foreach (var item in feed.Items)
                {
                    Console.WriteLine($"[{item.PublishingDate}] {item.Title} - {item.Link}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                Console.Error.WriteLine($"Exception:{Environment.NewLine}{ex}");

                if (ex.InnerException is not null)
                {
                    Console.Error.WriteLine($"Inner Exception:{Environment.NewLine}{ex.InnerException}");
                }
            }
            finally
            {
                Console.WriteLine("================================================");
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
