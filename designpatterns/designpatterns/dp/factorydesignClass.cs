namespace desgnpatterns.dp;

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