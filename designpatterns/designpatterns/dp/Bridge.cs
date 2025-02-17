namespace designpatterns.dp;

// Abstraction Interface
public interface IShapeClass
{
    void Draw();
}

// Implementation Interface
public interface IDrawingAPI
{
    void DrawCircle(double x, double y, double radius);
}

// Concrete Implementations
public class VectorDrawingAPI : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius)
    {
        Console.WriteLine($"Vector API: Drawing circle at ({x},{y}) with radius {radius}");
    }
}

public class RasterDrawingAPI : IDrawingAPI
{
    public void DrawCircle(double x, double y, double radius)
    {
        Console.WriteLine($"Raster API: Drawing circle at ({x},{y}) with radius {radius}");
    }
}

// Refined Abstraction (Shape Implementations using the Bridge)
public class CircleShape : IShapeClass
{
    private double _x, _y, _radius;
    private IDrawingAPI _drawingAPI;

    public CircleShape(double x, double y, double radius, IDrawingAPI drawingAPI)
    {
        _x = x;
        _y = y;
        _radius = radius;
        _drawingAPI = drawingAPI;
    }

    public void Draw()
    {
        _drawingAPI.DrawCircle(_x, _y, _radius);
    }
}
