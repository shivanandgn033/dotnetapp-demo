using AsyncExamples.asynchprogramming;
    //.........................................................................................
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

        //............................................................................
        var example = new AsyncEventExample();

        // Subscribe to the event.
        example.TaskCompleted += (sender, e) =>
        {
            Console.WriteLine($"Event received: Task completed with result: {e.Result}");
        };

        // Start multiple tasks concurrently.
        Task task1 = example.PerformTaskAsync("Task 1");
        Task task2 = example.PerformTaskAsync("Task 2");
        Task task3 = example.PerformTaskAsync("Task 3");

        // Wait for all tasks to complete. This is optional, as the event will signal completion.
        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("All tasks started. Event handlers will process results as tasks complete.");

        //Because of the when all, the program will wait here until all tasks are complete, and all events are fired.
        Console.WriteLine("Main method finished");


        //............................................................................