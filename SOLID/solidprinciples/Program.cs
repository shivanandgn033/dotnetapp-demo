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

//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,

//Using methods: Methods implement the DRY principle by allowing you to centralize code that will be used in multiple parts of your application. It is often easier to move the code that is repeated in multiple places into a method and call it from everywhere. Any required changes can be done at a single location in your code base.
//Using classes and inheritance: When lines of code are spread across many classes and methods, they can be relocated to a parent class, which all of the derived classes can then inherit. This approach ensures that modifications to the code can be made in a single location rather than in each separate class that extends the base class.
//Using interfaces: Code shared across classes without a common base class may be moved into an interface and implemented by the relevant classes. In this way, the code will be shared throughout all types, such that if you ever need to modify the code, you only have to update the interface.
            Console.WriteLine("\n..........................................................................");
            Console.WriteLine("\n.DRY principle example");
            int a = 5;
            int b = 10;
            int x = 10;
            int y = 20;
            // Calling the AddIntegers method twice
            int s1 = DRY.AddIntegers(a, b);
            int s2 = DRY.AddIntegers(x, y);
            Console.WriteLine($"Sum of a and b is: {s1}, " +
                $"Sum of x and y is: {s2}");
            Console.ReadKey();
            Console.WriteLine("\n..........................................................................");

//...........................................................................

    // In this example, the Author class follows the YAGNI principle of implementing minimal functionality. For this simple example, we have considered only two attributes of the Author entity, i.e. the first name and last name.
    // We have not implemented unnecessary characteristics like age, address, or telephone number. We may implement these attributes later, if we discover we have a use for them. In the meantime, we adhere to the YAGNI principle by not implementing unnecessary features and avoiding code bloat—additional features that may make the code harder to comprehend, use, and maintain.
    
            Console.WriteLine("\n..........................................................................");
            Console.WriteLine("\n.YOGNI principle example");

            Author author = new Author("Joydip", "Kanjilal");
            Console.WriteLine($"Full name: {author.GetAuthorName()}");
            Console.ReadKey();
            Console.WriteLine("\n..........................................................................");
//...........................................................................