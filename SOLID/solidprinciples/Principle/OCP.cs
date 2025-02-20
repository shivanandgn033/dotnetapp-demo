namespace solidprinciples.Principle;
// Open/Closed Principle (OCP)

// Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification. 
// This means you should be able to add new functionality without changing existing code. 
// Abstract classes and interfaces are key to this.



// Bad example - Modifying the class to add new shape types

// public class Shape
// {
//     public string Type { get; set; } // "Rectangle", "Circle"
//     public void Draw()
//     {
//         if (Type == "Rectangle") { /* ... */ }
//         else if (Type == "Circle") { /* ... */ }
//     }
// }




// Good example - Using inheritance and polymorphism
public abstract class Shape
{
    public abstract void Draw();
}

public class Rectangle : Shape
{
    public override void Draw() { /* ... */ }
}

public class Circle : Shape
{
    public override void Draw() { /* ... */ }
}

// Adding a new shape doesn't require modifying existing Shape or its subclasses
public class Triangle : Shape
{
    public override void Draw() { /* ... */ }
}
