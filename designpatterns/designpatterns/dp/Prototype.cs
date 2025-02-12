namespace designpatterns.dp;
using System;



// Prototype interface (or abstract class)
public interface IAnimal 
{
    string Name { get; set; }
    string MakeSound();
    //IAnimal Clone(); // Explicit Clone method
}

// Concrete Prototype (Sheep)
public class Sheep : IAnimal, ICloneable
{
    public string Name { get; set; }

    public Sheep(string name)
    {
        Name = name;
    }

    public string MakeSound()
    {
        return "Baa!";
    }

    public object  Clone()
    {
        //return (Sheep)this.MemberwiseClone(); // Shallow copy
        //return new Sheep(this);
         return this.MemberwiseClone(); 
    }

    // Example of a "deep copy" if needed (important for complex objects)
    public Sheep DeepClone()
    {
        Sheep clonedSheep = (Sheep)this.MemberwiseClone();
        // If Sheep had complex members (e.g., a list of toys), you'd 
        // need to clone those as well to prevent shared state issues.
        // For this simple example, MemberwiseClone is sufficient.
        return clonedSheep;
    }
}

// Concrete Prototype (Dog)
public class Dog : IAnimal, ICloneable
{
    public string Name { get; set; }

    public Dog(string name)
    {
        Name = name;
    }

    public string MakeSound()
    {
        return "Woof!";
    }

    public object  Clone()
    {
          return this.MemberwiseClone();  
        //return (Dog)this.MemberwiseClone(); // Shallow copy
        //return new Dog(this);
    }
}
