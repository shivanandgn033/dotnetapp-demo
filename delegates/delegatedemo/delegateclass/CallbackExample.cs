namespace delegatedemo.delegateclass;

public class CallbackExample
{
 // Delegate type for the callback function
    public delegate void OperationCallback(int result);

    // Method that performs an operation and uses a callback
    public static void PerformOperation(int x, int y, OperationCallback callback)
    {
        Console.WriteLine("Performing operation...");
        int result = x + y; // Example operation: addition
        Console.WriteLine("Operation completed.");

        // Call the callback function with the result
        if (callback != null)
        {
            callback(result);
        }
    }

    // Callback method 1
    public static void DisplayResult(int result)
    {
        Console.WriteLine($"Result displayed: {result}");
    }

    // Callback method 2
    public static void LogResult(int result)
    {
        Console.WriteLine($"Result logged: {result}");
        // Here you might log the result to a file, database, etc.
    }

}
