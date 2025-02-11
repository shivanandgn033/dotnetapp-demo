namespace desgnpatterns.dp;
// Interfaces for the products (UI elements)
interface IButton
{
    void Render();
}

interface ILabel
{
    void Display();
}

// Concrete products (Modern theme)
class ModernButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Modern Button");
    }
}

class ModernLabel : ILabel
{
    public void Display()
    {
        Console.WriteLine("Displaying a Modern Label");
    }
}

// Concrete products (Classic theme)
class ClassicButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Classic Button");
    }
}

class ClassicLabel : ILabel
{
    public void Display()
    {
        Console.WriteLine("Displaying a Classic Label");
    }
}

// Abstract Factory interface
interface IGUIFactory
{
    IButton CreateButton();
    ILabel CreateLabel();
}

// Concrete Factories (Modern and Classic)
class ModernGUIFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new ModernButton();
    }

    public ILabel CreateLabel()
    {
        return new ModernLabel();
    }
}

class ClassicGUIFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new ClassicButton();
    }

    public ILabel CreateLabel()
    {
        return new ClassicLabel();
    }
}

// Client code
class Client
{
    private IGUIFactory _factory;

    public Client(IGUIFactory factory)
    {
        _factory = factory;
    }

    public void BuildUI()
    {
        IButton button = _factory.CreateButton();
        ILabel label = _factory.CreateLabel();

        button.Render();
        label.Display();
    }


}


// Key Benefits of Abstract Factory:

// Decoupling: The client code is decoupled from the concrete implementations of the UI elements. You can easily switch between themes (factories) without modifying the client code.
// Consistency: The Abstract Factory ensures that you get a consistent set of related objects. You won't accidentally mix Modern buttons with Classic labels.
// Extensibility: Adding new themes is easy. Just create a new concrete factory and the corresponding concrete product classes. No changes are needed to existing code.
// This example shows how the Abstract Factory pattern lets you manage families of related objects in a clean and flexible way, especially useful when you have variations or themes in your application.