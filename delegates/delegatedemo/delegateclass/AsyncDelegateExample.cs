using System;
using System.Threading;
namespace delegatedemo.delegateclass;
public class AsyncDelegateExample
{
    // Delegate for the asynchronous operation
    public delegate int LongRunningOperation(int input);

    public static int PerformLongOperation(int input)
    {
        Console.WriteLine($"Long operation started with input: {input}. Thread: {Thread.CurrentThread.ManagedThreadId}");
        // Simulate a long-running task (e.g., network request, file processing)
        Thread.Sleep(3000); // Sleep for 3 seconds
        Console.WriteLine($"Long operation completed. Thread: {Thread.CurrentThread.ManagedThreadId}");
        return input * 2; // Return a result
    }

    public static void OperationCompletedCallback(IAsyncResult ar)
    {
        Console.WriteLine($"Callback called. Thread: {Thread.CurrentThread.ManagedThreadId}");
        // Retrieve the delegate from the IAsyncResult
        AsyncDelegateExample.LongRunningOperation del = (AsyncDelegateExample.LongRunningOperation)ar.AsyncState;

        // End the asynchronous operation and retrieve the result
        int result = del.EndInvoke(ar);

        Console.WriteLine($"Operation result: {result}");
    }

    public static void testasynccallback()
    {
        Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

        // Create a delegate instance
        LongRunningOperation operation = new LongRunningOperation(PerformLongOperation);

        // Begin the asynchronous operation
        IAsyncResult asyncResult = operation.BeginInvoke(10, OperationCompletedCallback, operation);

        Console.WriteLine("Main thread continues to execute while the operation runs in the background.");

        // Do other work in the main thread
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main thread doing work: {i}. Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
        }

        // Wait for the asynchronous operation to complete (optional)
        // asyncResult.AsyncWaitHandle.WaitOne(); //Blocks the current thread until the async operation finishes
        // Console.WriteLine("Asynchronous operation finished.");

        Console.WriteLine("Main thread finished.");
    }



}
