// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using desgnpatterns.dp;

        string shapeType = "circle"; // Get from user input
        //string shapeType = "Square";
        IShape shape = ShapeFactory.GetShape(shapeType);

        if (shape != null)
        {
            shape.Draw();
        }

          // Get the singleton instance
        Logger logger = Logger.Instance;

        // Use the logger
        logger.Log("Application started.");
        logger.Log("An error occurred.");

        // ... other parts of the code can also access the same instance ...
        Logger anotherLogger = Logger.Instance;
        anotherLogger.Log("Another message"); // This will also go to the same log (console in this example)

        // Verify that it is the same instance
        Console.WriteLine(object.ReferenceEquals(logger, anotherLogger)); // True
   
        // Choose the theme (factory) at runtime
        IGUIFactory modernFactory = new ModernGUIFactory();
        Client modernClient = new Client(modernFactory);
        Console.WriteLine("Modern UI:");
        modernClient.BuildUI();


        IGUIFactory classicFactory = new ClassicGUIFactory();
        Client classicClient = new Client(classicFactory);
        Console.WriteLine("\nClassic UI:");
        classicClient.BuildUI();
    