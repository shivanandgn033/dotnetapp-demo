// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using designpatterns.dp;


//.............Factory desgin pattern...................................................
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("Factory desgin pattern:");
        string shapeType = "circle"; // Get from user input
        //string shapeType = "Square";
        IShape shape = ShapeFactory.GetShape(shapeType);

        if (shape != null)
        {
            shape.Draw();
        }

        Console.WriteLine("\n");
        
//.......................................................................................


//...................Singleton design pattern............................................
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("Singaletone design pattern:");
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
        Console.WriteLine("\n");
//...........................................................................................        
        Console.WriteLine("\n..........................................................................");
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
        Console.WriteLine("\n");
 //..............................................................................


 //..............................................................................
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("Prototype desgin pattern:");
     // Create prototypes
        Sheep originalSheep = new Sheep("Dolly");
        Dog originalDog = new Dog("Buddy");

        // Clone the prototypes
        IAnimal clonedSheep1 = (Sheep)originalSheep.Clone();
        clonedSheep1.Name = "Dolly 2"; // Modify the clone

        IAnimal clonedDog = (Dog)originalDog.Clone();
        clonedDog.Name = "Max";

        IAnimal clonedSheep2 =(Sheep)originalSheep.Clone();; // Another clone

        // Demonstrate that the original and clones are different objects
        Console.WriteLine($"Original Sheep: {originalSheep.Name}, Sound: {originalSheep.MakeSound()}");
        Console.WriteLine($"Cloned Sheep 1: {clonedSheep1.Name}, Sound: {clonedSheep1.MakeSound()}");
        Console.WriteLine($"Cloned Sheep 2: {clonedSheep2.Name}, Sound: {clonedSheep2.MakeSound()}");
        Console.WriteLine($"Original Dog: {originalDog.Name}, Sound: {originalDog.MakeSound()}");
        Console.WriteLine($"Cloned Dog: {clonedDog.Name}, Sound: {clonedDog.MakeSound()}");

        // Important: Notice how the original sheep is unaffected by the changes to the clones.
        Console.WriteLine("\n");
 //..............................................................................

        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nBuilder design pattern:");

        IPizzaBuilder pepperoniBuilder = new PepperoniPizzaBuilder();
        PizzaDirector director = new PizzaDirector(pepperoniBuilder);

        director.ConstructPepperoniPizza();
        Pizza pepperoniPizza = pepperoniBuilder.GetPizza();
        Console.WriteLine(pepperoniPizza);

        List<string> customToppings = new List<string> { "Mushrooms", "Onions", "Olives" };
        director.ConstructCustomPizza("Thick", "Pesto", customToppings, "Medium");
        Pizza customPizza = pepperoniBuilder.GetPizza(); // Reuse the builder
        Console.WriteLine(customPizza);
        Console.WriteLine("\n");

        //..........................................................................
                // Create the chain of handlers
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nchain of handlers design pattern:");
        HelpHandler buttonHandler = new ButtonHelpHandler();
        HelpHandler formHandler = new FormHelpHandler();
        HelpHandler applicationHandler = new ApplicationHelpHandler();

        // Define the chain order: Button -> Form -> Application
        buttonHandler.SetNext(formHandler).SetNext(applicationHandler); // Fluent chaining setup

        // Simulate help requests
        HelpRequest buttonHelp = new HelpRequest("Button");
        HelpRequest formHelp = new HelpRequest("Form");
        HelpRequest generalHelp = new HelpRequest("General");
        HelpRequest unknownHelp = new HelpRequest("Menu"); // No specific handler

        Console.WriteLine("--- Processing Help Requests ---");

        Console.WriteLine("\nRequesting Button Help:");
        buttonHandler.HandleHelpRequest(buttonHelp); // Start with the first handler in the chain

        Console.WriteLine("\nRequesting Form Help:");
        buttonHandler.HandleHelpRequest(formHelp);

        Console.WriteLine("\nRequesting General Help:");
        buttonHandler.HandleHelpRequest(generalHelp);

        Console.WriteLine("\nRequesting Unknown Help (Menu):");
        buttonHandler.HandleHelpRequest(unknownHelp); // Will go through the chain and reach the end

        Console.ReadKey();
        //..........................................................................

        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nCommand design pattern:");
        // 5 client call
        TextEditor editor = new TextEditor();
        EditorInvoker invoker = new EditorInvoker(editor);

        // Perform some actions
        invoker.ExecuteCommand(new InsertTextCommand(editor, "Hello "));
        invoker.ExecuteCommand(new InsertTextCommand(editor, "World!"));
        invoker.ExecuteCommand(new DeleteTextCommand(editor)); // Delete '!'

        Console.WriteLine($"\nCurrent Text: '{editor.GetText()}'\n");

        // Undo the last command (DeleteText)
        invoker.UndoLastCommand();

        Console.WriteLine($"\nCurrent Text after Undo: '{editor.GetText()}'\n");

        // Undo again (Undo Insert "World!")
        invoker.UndoLastCommand();

        Console.WriteLine($"\nCurrent Text after 2nd Undo: '{editor.GetText()}'\n");

        // Try to undo when no more commands in history
        invoker.UndoLastCommand();


        Console.ReadKey();


        //..........................................................................
        
                // Example: (x AND y) OR (NOT x AND true)

        // Build the Abstract Syntax Tree (AST)

        // Terminal Expressions
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nInterpreter design pattern:");
        VariableExpression x = new VariableExpression("x");
        VariableExpression y = new VariableExpression("y");
        LiteralExpression trueLiteral = new LiteralExpression(true);

        // Non-terminal Expressions
        AndExpression andExpression1 = new AndExpression(x, y);         // (x AND y)
        NotExpression notExpression = new NotExpression(x);           // (NOT x)
        AndExpression andExpression2 = new AndExpression(notExpression, trueLiteral); // (NOT x AND true)
        OrExpression orExpression = new OrExpression(andExpression1, andExpression2); // (x AND y) OR (NOT x AND true)

        // Context - set variable values
        Context context = new Context();
        context.SetVariable("x", true);
        context.SetVariable("y", false);

        // Interpret the expression
        bool result = orExpression.Interpret(context);

        Console.WriteLine($"Expression: (x AND y) OR (NOT x AND true)");
        Console.WriteLine($"Result for x=true, y=false: {result}"); // Output: Result for x=true, y=false: True

        context.SetVariable("x", false);
        context.SetVariable("y", true);
        result = orExpression.Interpret(context);
        Console.WriteLine($"Result for x=false, y=true: {result}"); // Output: Result for x=false, y=true: False


        Console.ReadKey();
        
        //..........................................................................
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nAdapter design pattern:");
        // Using the Legacy Reporting System through the Adapter

        // 1. Instantiate the Legacy Adaptee
        LegacyReportGenerator legacyGenerator = new LegacyReportGenerator();

        // 2. Create the Adapter, wrapping the Legacy Generator
        INewReportGenerator adapter = new LegacyReportAdapter(legacyGenerator);

        // 3. Instantiate the New Reporting Application, using the Adapter
        NewReportingApplication newApp = new NewReportingApplication(adapter);

        // 4. Generate and Display the report using the New Application (which internally uses the Adapter and Legacy System)
        DateTime startDate = new DateTime(2023, 10, 26);
        DateTime endDate = new DateTime(2023, 10, 27);
        newApp.DisplaySalesReport(startDate, endDate);


        Console.ReadKey();
        //..........................................................................
        Console.WriteLine("\n..........................................................................");

        //......................................................................
        Console.WriteLine("\n..........................................................................");
        Console.WriteLine("\nBridge design pattern:");
        IShapeClass vectorCircle = new CircleShape(1, 2, 5, new VectorDrawingAPI());
        IShapeClass rasterCircle = new CircleShape(5, 7, 10, new RasterDrawingAPI());

        vectorCircle.Draw(); // Vector API: Drawing circle at (1,2) with radius 5
        rasterCircle.Draw(); // Raster API: Drawing circle at (5,7) with radius 10
        Console.WriteLine("\n..........................................................................");
        //.....................................................................