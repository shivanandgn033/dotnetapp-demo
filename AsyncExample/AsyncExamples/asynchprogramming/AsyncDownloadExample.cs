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

// Explanation:

// DownloadDataAsync:
// It's marked as async and returns Task<string>.
// It uses HttpClient to download data from a URL.
// await client.GetAsync(url) suspends execution until the HTTP request completes.
// response.EnsureSuccessStatusCode(); throws an exception if the response is not successful.
// await response.Content.ReadAsStringAsync() suspends execution until the content is read.
// It handles potential HttpRequestException errors.
// Main:
// It's marked as async and returns Task.
// It calls DownloadDataAsync and awaits the result.
// It then displays the downloaded data.
// Benefits displayed: the Console lines will print while the program is awaiting the download, keeping the program responsive.
// This example demonstrates how to use async and await to perform asynchronous network operations in C#. Remember to handle exceptions properly and consider using ConfigureAwait when necessary.