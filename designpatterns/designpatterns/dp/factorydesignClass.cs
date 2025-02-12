namespace designpatterns.dp;

// 1. Define an interface or abstract class for the products
public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw() { Console.WriteLine("Drawing a circle"); }
}

public class Square : IShape
{
    public void Draw() { Console.WriteLine("Drawing a square"); }
}

// 2. Create the Factory class
public class ShapeFactory
{
    public static IShape GetShape(string shapeType)
    {
        if (shapeType.Equals("circle", StringComparison.OrdinalIgnoreCase))
        {
            return new Circle();
        }
        else if (shapeType.Equals("square", StringComparison.OrdinalIgnoreCase))
        {
            return new Square();
        }
        // ... more else if for other shapes ...
        else
        {
            return null; // Or throw an exception for invalid shape type
        }
    }
}



// Explanation:

// 1) IShape Interface: Defines the contract for all shape objects.
// 2) Concrete Shape Classes: Circle and Square implement the IShape interface.
// 3) ShapeFactory: This class is responsible for creating the appropriate shape object based on the shapeType input. The GetShape method is a static factory method.
// 4) Client: The client code now interacts with the ShapeFactory to get the desired shape. It doesn't need to know anything about the concrete shape classes.

// Benefits of this approach:

// 1 Loose Coupling: The client is decoupled from the concrete shape classes.
// 2 Extensibility: Adding a new shape (e.g., Rectangle) only requires creating a new class that implements IShape and adding a new else if condition in the ShapeFactory. The client code doesn't need to be modified.
// 3 Maintainability: The creation logic is centralized in the ShapeFactory, making it easier to manage and modify.

// This example demonstrates a simple Factory.  More complex scenarios might involve Abstract Factories or other variations.  However, the core principle remains the same: deferring instantiation to a factory class to improve flexibility and maintainability.