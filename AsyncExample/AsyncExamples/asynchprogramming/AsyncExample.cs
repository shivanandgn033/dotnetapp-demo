using System;
using System.Threading.Tasks;
namespace AsyncExamples.asynchprogramming;

public class AsyncExample
{
       // Asynchronous method that simulates a long-running operation.
    public static async Task<string> DownloadDataAsync(string url)
    {
        Console.WriteLine($"Starting download from {url}...");

        // Simulate a delay (e.g., network request, file I/O).
        await Task.Delay(2000); // Wait for 2 seconds.

        Console.WriteLine($"Download from {url} completed.");
        return $"Data from {url}"; // Return some simulated data.
    }

    // Asynchronous method that processes data.
    public static async Task ProcessDataAsync(string data)
    {
        Console.WriteLine($"Processing data: {data}");
        await Task.Delay(1000); // Simulate processing time.
        Console.WriteLine($"Data processed.");
    }

    public static async Task ConfigureAwaitExample()
    {
        Console.WriteLine("ConfigureAwaitExample Started");
        await Task.Delay(1000).ConfigureAwait(false); //forces continuation on a threadpool thread.
        Console.WriteLine("ConfigureAwaitExample after delay");
        await Task.Delay(1000).ConfigureAwait(true); //forces continuation on original context if available, otherwise threadpool.
        Console.WriteLine("ConfigureAwaitExample after second delay");

    }
    
}
