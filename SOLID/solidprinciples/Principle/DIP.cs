namespace solidprinciples.Principle;

// Dependency Inversion Principle (DIP)

//High-level modules should not depend on low-level modules. 
//Both should depend on abstractions. Abstractions should not depend on details. 
//Details should depend on abstractions.

// // Bad example - High-level depends on low-level
// public class Button
// {
//     private Lamp _lamp = new Lamp(); // Direct dependency

//     public void Press()
//     {
//         _lamp.TurnOn();
//     }
// }

// public class Lamp
// {
//     public void TurnOn() { /* ... */ }
// }


// Good example - Dependency inversion
public interface ISwitchable
{
    void TurnOn();
}

public class Button
{
    private ISwitchable _device; // Depends on abstraction

    public Button(ISwitchable device) // Injected dependency
    {
        _device = device;
    }

    public void Press()
    {
        _device.TurnOn();
    }
}

public class Lamp : ISwitchable
{
    public void TurnOn() { /* ... */ }
}

public class Fan : ISwitchable
{
    public void TurnOn() { /* ... */ }
}

// Now the Button can work with any ISwitchable device!