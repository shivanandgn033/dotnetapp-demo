using System;
using System.Threading.Tasks;
namespace AsyncExamples.asynchprogramming;
public class AsyncDownloadExample
{
     public static async Task<string> DownloadDataAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine($"Starting download from {url}...");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Throw if not a success code.
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Download from {url} completed.");
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error downloading from {url}: {ex.Message}");
                return null;
            }
        }
}
}
