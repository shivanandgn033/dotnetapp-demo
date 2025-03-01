using AsyncExamples.asynchprogramming;

        string url1 = "https://example.com/data1";
        string url2 = "https://example.com/data2";

        // Start downloads concurrently.
        Task<string> downloadTask1 = AsyncExample.DownloadDataAsync(url1);
        Task<string> downloadTask2 = AsyncExample.DownloadDataAsync(url2);

        // Wait for both downloads to complete and get the results.
        string data1 = await downloadTask1;
        string data2 = await downloadTask2;

        // Process the downloaded data concurrently.
        Task processTask1 = AsyncExample.ProcessDataAsync(data1);
        Task processTask2 = AsyncExample.ProcessDataAsync(data2);

        // Wait for both processing tasks to complete.
        await Task.WhenAll(processTask1, processTask2);

        Console.WriteLine("All tasks completed.");

        //Another example showing how to use ConfigureAwait

        Console.WriteLine("ConfigureAwait Example");

        await AsyncExample.ConfigureAwaitExample();

        Console.WriteLine("End of ConfigureAwait Example");