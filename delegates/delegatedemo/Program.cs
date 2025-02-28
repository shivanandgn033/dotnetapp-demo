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
             // Example 1: Transform int to string
        int number = 123;
        string numberString = GenericDelegateExample.Transform(number, n => n.ToString()); //Using lambda expression
        Console.WriteLine($"Transformed number: {numberString}");

        // Example 2: Transform string to int
        string text = "456";
        int parsedNumber = GenericDelegateExample.Transform(text, s => int.Parse(s));
        Console.WriteLine($"Parsed number: {parsedNumber}");

        // Example 3: Process a string
        string message = "Hello, world!";
        GenericDelegateExample.Process(message, m => Console.WriteLine($"Message: {m.ToUpper()}"));

        // Example 4: Process an integer
        int value = 7;
        GenericDelegateExample.Process(value, v => Console.WriteLine($"Value squared: {v * v}"));

        // Example 5: Validate an integer
        int age = 25;
        bool isAdult = GenericDelegateExample.IsValid(age, a => a >= 18);
        Console.WriteLine($"Is adult: {isAdult}");

        // Example 6: Validate a string
        string username = "john_doe";
        bool isValidUsername = GenericDelegateExample.IsValid(username, u => u.Length >= 5);
        Console.WriteLine($"Is valid username: {isValidUsername}");

    //......................................................................................................
        lambdaexpression.lambdaexpressions();
   //...........................................................................................................
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