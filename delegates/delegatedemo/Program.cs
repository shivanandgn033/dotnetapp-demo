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