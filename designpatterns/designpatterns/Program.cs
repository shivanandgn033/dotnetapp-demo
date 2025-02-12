// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using designpatterns.dp;


//.............Factory desgin pattern...................................................
        Console.WriteLine("Factory desgin pattern:");
        string shapeType = "circle"; // Get from user input
        //string shapeType = "Square";
        IShape shape = ShapeFactory.GetShape(shapeType);

        if (shape != null)
        {
            shape.Draw();
        }
//.......................................................................................


//...................Singleton design pattern............................................
          Console.WriteLine("Singaltone desgin pattern:");
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
//...........................................................................................        
        Console.WriteLine("Abstract factory desgin pattern:");
        // Choose the theme (factory) at runtime
        IGUIFactory modernFactory = new ModernGUIFactory();
        Client modernClient = new Client(modernFactory);
        Console.WriteLine("Modern UI:");
        modernClient.BuildUI();


        IGUIFactory classicFactory = new ClassicGUIFactory();
        Client classicClient = new Client(classicFactory);
        Console.WriteLine("\nClassic UI:");
        classicClient.BuildUI();

 //..............................................................................


 //..............................................................................
      Console.WriteLine("Prototype desgin pattern:");
     // Create prototypes
        Sheep originalSheep = new Sheep("Dolly");
        Dog originalDog = new Dog("Buddy");

        // Clone the prototypes
        IAnimal clonedSheep1 = originalSheep.Clone();
        clonedSheep1.Name = "Dolly 2"; // Modify the clone

        IAnimal clonedDog = originalDog.Clone();
        clonedDog.Name = "Max";

        IAnimal clonedSheep2 = originalSheep.Clone(); // Another clone

        // Demonstrate that the original and clones are different objects
        Console.WriteLine($"Original Sheep: {originalSheep.Name}, Sound: {originalSheep.MakeSound()}");
        Console.WriteLine($"Cloned Sheep 1: {clonedSheep1.Name}, Sound: {clonedSheep1.MakeSound()}");
        Console.WriteLine($"Cloned Sheep 2: {clonedSheep2.Name}, Sound: {clonedSheep2.MakeSound()}");
        Console.WriteLine($"Original Dog: {originalDog.Name}, Sound: {originalDog.MakeSound()}");
        Console.WriteLine($"Cloned Dog: {clonedDog.Name}, Sound: {clonedDog.MakeSound()}");

        // Important: Notice how the original sheep is unaffected by the changes to the clones.
 //..............................................................................
    