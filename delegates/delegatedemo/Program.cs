using System;
using delegatedemo.delegateclass;


    // Delegate example 
     DelegateExample.calldelegateExample();




    //................................................................................... 

     //callback function parameter delegate..

     // Using the DisplayResult callback
        CallbackExample.PerformOperation(10, 5, CallbackExample.DisplayResult);

        Console.WriteLine(); // Add a blank line for readability

        // Using the LogResult callback
        CallbackExample.PerformOperation(20, 8, CallbackExample.LogResult);

        Console.WriteLine();

        //using an anonymous method as a callback
        CallbackExample.PerformOperation(5, 5, delegate(int result) {
            Console.WriteLine($"Anonymous callback: Result is {result}");
        });

        Console.WriteLine();

        //using a lambda expression as a callback
        CallbackExample.PerformOperation(100, 2, (result) => Console.WriteLine($"Lambda callback: Result = {result}"));
    //.........................................................................................................

      AsyncDelegateExample.testasynccallback();
     //   Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

     //    // Create a delegate instance
     //    AsyncDelegateExample.LongRunningOperation operation = new AsyncDelegateExample.LongRunningOperation(AsyncDelegateExample.PerformLongOperation);

     //    // Begin the asynchronous operation
     //    IAsyncResult asyncResult = operation.BeginInvoke(10, AsyncDelegateExample.OperationCompletedCallback, operation);

     //    Console.WriteLine("Main thread continues to execute while the operation runs in the background.");

     //    // Do other work in the main thread
     //    for (int i = 0; i < 5; i++)
     //    {
     //        Console.WriteLine($"Main thread doing work: {i}. Thread: {Thread.CurrentThread.ManagedThreadId}");
     //        Thread.Sleep(500);
     //    }

     //    // Wait for the asynchronous operation to complete (optional)
     //    // asyncResult.AsyncWaitHandle.WaitOne(); //Blocks the current thread until the async operation finishes
     //    // Console.WriteLine("Asynchronous operation finished.");

     //    Console.WriteLine("Main thread finished.");


    //......................................................................................................