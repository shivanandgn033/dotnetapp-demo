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
