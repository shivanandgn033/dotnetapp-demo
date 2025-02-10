namespace desgnpatterns.dp;

public class Logger
{
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

    private Logger() { }

    public static Logger Instance => _instance.Value;

    public void Log(string message)
    {
        Console.WriteLine($"Logging: {message}");
    }
}


// public class Logger
// {
//     private static Logger _instance; // Private static instance

//     // Private constructor to prevent direct instantiation
//     private Logger() { }

//     // Public static method to get the instance
//     public static Logger Instance
//     {
//         get
//         {
//             if (_instance == null)
//             {
//                 _instance = new Logger();
//             }
//             return _instance;
//         }
//     }

//     public void Log(string message)
//     {
//         // Write the message to the log file (implementation details omitted)
//         Console.WriteLine($"Logging: {message}"); // For demonstration
//     }
// }

// Explnaintion
// Private Static Instance: The _instance variable is a private static member that holds the single instance of the Logger class.  It is initialized to null.

// Private Constructor: The constructor of the Logger class is private.  This prevents other classes from creating new instances of Logger using the new keyword.

// Public Static Instance Property: The Instance property is a public static property that provides access to the singleton instance.  The get accessor checks if an instance already exists.  If not, it creates a new instance and stores it in the _instance variable.  It then returns the instance.  This ensures that only one instance is ever created.

// Client Code: The client code uses the Logger.Instance property to get the singleton instance.  It can then call the Log method to write messages to the log.  All parts of the application that access Logger.Instance will get the same instance.

// Thread Safety (Important Consideration):

// The basic Singleton implementation shown above is not thread-safe.  In a multithreaded environment, multiple threads could potentially enter the if (_instance == null) block simultaneously and create multiple instances.  This violates the Singleton pattern.

// Thread-Safe Singleton Implementations:

// There are several ways to make a Singleton thread-safe:

// Double-Checked Locking: This is a common and efficient approach.
// Lazy Initialization: Uses Lazy<T> to ensure thread-safe initialization. This is generally the preferred method in modern C#.