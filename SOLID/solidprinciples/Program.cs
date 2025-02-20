using solidprinciples.Principle;


// Now, we don't have the same problem as before.
 static void PrintArea(IHasArea shape1)
{
    Console.WriteLine($"Area: {shape1.Area()}");
}

// We can create a method to set the width and height for a rectangle
 static void SetRectangleDimensions(RectangleClass rect, int width, int height)
{
    rect.Width = width;
    rect.Height = height;
}

//.................................................
Console.WriteLine("\n..........................................................................");

RectangleClass rect = new RectangleClass { Width = 5, Height = 10 };
SquareClass sq = new SquareClass { Side = 5 };

PrintArea(rect); // Output: 50
PrintArea(sq); // Output: 25



SetRectangleDimensions(rect, 20, 10);
Console.WriteLine($"Rectangle Area: {rect.Area()}"); // Output: 200

// We can't use SetRectangleDimensions with a square.
// SetRectangleDimensions(sq, 20, 20); // This won't compile because sq is a Square, not a Rectangle.
 Console.WriteLine("\n..........................................................................");
// //........................................................................
