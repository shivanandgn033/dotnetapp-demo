using ExceptionHadling;
using Microsoft.Extensions.Logging;
using System;
//...........................................................................................
ExceptionHandlingExample.exceptioncall();

//...........................................................................................
        // Setup logger (example using console logger)
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information); // Adjust as needed
        });

        ILogger<ExceptionHandlingWithLoggerExample> logger = loggerFactory.CreateLogger<ExceptionHandlingWithLoggerExample>();
        var example = new ExceptionHandlingWithLoggerExample(logger);

        try
        {
            example.PerformOperation("abc"); // Will throw FormatException
            //example.PerformOperation("0"); // Will throw DivideByZeroException
            //example.PerformOperation("10"); //Will succeed.
        }
        catch (Exception)
        {
            //Catching the re-thrown exception.
            logger.LogInformation("Exception caught in Main.");
        }
//......................................................................................................