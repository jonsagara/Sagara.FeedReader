namespace CodeHollow.FeedReader.ConsoleSample;

class Program
{
    static async Task Main()
    {
        const string prompt = "Please enter feed url or exit to stop the program:";
        Console.WriteLine(prompt);

        while (true)
        {
            try
            {
                string? url = Console.ReadLine();
                if (url?.Equals("exit", StringComparison.InvariantCultureIgnoreCase) == true)
                {
                    break;
                }

                var urls = (await FeedReader.GetFeedUrlsFromUrlAsync(url)).ToArray();

                string? feedUrl;
                if (urls is null || urls.Length < 1)
                {
                    feedUrl = url;
                }
                else if (urls.Length == 1)
                {
                    feedUrl = urls.First().Url;
                }
                else if (urls.Length == 2)
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

                    if (!int.TryParse(input, out int index) || index < 1 || index > urls.Length)
                    {
                        Console.WriteLine("Wrong input. Press key to exit");
                        Console.ReadKey();
                        return;
                    }

                    feedUrl = urls.ElementAt(index).Url;
                }

                var feed = await FeedReader.ReadAsync(feedUrl);

                foreach (var item in feed.Items)
                {
                    Console.WriteLine($"{item.Title} - {item.Link}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.InnerException?.Message}{Environment.NewLine}{ex.InnerException}");
            }
            finally
            {
                Console.WriteLine("================================================");
                Console.WriteLine(prompt);
            }
        }
    }
}
