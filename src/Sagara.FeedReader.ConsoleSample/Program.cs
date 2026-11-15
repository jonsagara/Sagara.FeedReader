using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sagara.FeedReader;
using Sagara.FeedReader.ConsoleSample;
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
    var feedReaderSvc = serviceScope.ServiceProvider.GetRequiredService<IFeedReader>();
    var logger = Log.Logger.ForContext<Program>();


    //
    // Main loop
    //

    HashSet<string> exitWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "exit", "quit", "q",
    };

    var prompt = $"Please enter a page or feed URL, including https://, or {string.Join("/", exitWords)} to stop the program:";
    Console.WriteLine(prompt);

    var keepGoing = true;

    while (keepGoing)
    {
        try
        {
            string url = (Console.ReadLine() ?? string.Empty).Trim();
            if (exitWords.Contains(url))
            {
                keepGoing = false;
                break;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                Console.WriteLine($"'{url}' is not an absolute http or https URL. Include the scheme, e.g., https://example.com/.");
                continue;
            }

            // If the URL is a web page, find its feeds. If it's a feed, there won't be any links, and we'll read it directly.
            var pageResult = await feedReaderSvc.GetFeedUrlsFromPageAsync(uri);
            if (!pageResult.IsSuccess)
            {
                Console.WriteLine($"Could not read {uri}: [{pageResult.Error.Kind}] {pageResult.Error.Message}");
                continue;
            }

            var feedUrlsFromPage = pageResult.Value;

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

                // The menu is 1-based.
                feedUrl = feedUrlsFromPage.ElementAt(index - 1).Url;
            }

            var feedResult = await feedReaderSvc.GetFeedAsync(feedUrl);
            if (!feedResult.IsSuccess)
            {
                Console.WriteLine($"Could not read the feed at {feedUrl}: [{feedResult.Error.Kind}] {feedResult.Error.Message}");
                continue;
            }

            if (feedResult.FinalUri is not null && feedResult.FinalUri.AbsoluteUri != new Uri(feedUrl).AbsoluteUri)
            {
                Console.WriteLine($"(Redirected to {feedResult.FinalUri})");
            }

            var feed = feedResult.Value;

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
