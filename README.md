#### Design Patterns in C# with Examples
#### I. Creational Design Patterns
Creational patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

#### 1. Singleton

Intent: Ensure a class has only one instance and provide a global point of access to it.
Use Case: Logging, configuration management, thread pools, caching.
C# Example:
```C#
public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object _lock = new object(); // For thread safety

    private Singleton() { } // Private constructor

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock) // Thread-safe lazy initialization
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance is doing something.");
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Singleton instance1 = Singleton.Instance;
        Singleton instance2 = Singleton.Instance;

        Console.WriteLine($"Are instances the same? {ReferenceEquals(instance1, instance2)}"); // True
        instance1.DoSomething();
    }
}
```
#### 2. Factory Method

Intent: Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.
Use Case: When a class cannot anticipate the type of objects it needs to create, or when you want subclasses to specify the object creation.
C# Example:

```C#
// Product Interface
public interface IProduct
{
    string Operation();
}

// Concrete Products
public class ConcreteProductA : IProduct
{
    public string Operation() => "{Result of ConcreteProductA}";
}

public class ConcreteProductB : IProduct
{
    public string Operation() => "{Result of ConcreteProductB}";
}

// Creator Abstract Class
public abstract class Creator
{
    public abstract IProduct FactoryMethod(); // Factory Method

    public string SomeOperation()
    {
        var product = FactoryMethod();
        return "Creator: The same creator's operation, but the product type is determined by subclass - " + product.Operation();
    }
}

// Concrete Creators
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Creator[] creators = new Creator[] { new ConcreteCreatorA(), new ConcreteCreatorB() };

        foreach (var creator in creators)
        {
            Console.WriteLine(creator.SomeOperation());
        }
    }
}
```
#### 3. Abstract Factory   

Intent: Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
Use Case: When you need to create families of related products (e.g., UI themes with buttons, checkboxes, etc.), and you want to switch between these families easily.   
C# Example (Simplified UI Theme Factory):
```C#
// Abstract Products
public interface IButton { string Render(); }
public interface ICheckbox { string Render(); }

// Concrete Products (Windows Theme)
public class WindowsButton : IButton { public string Render() => "Windows Button"; }
public class WindowsCheckbox : ICheckbox { public string Render() => "Windows Checkbox"; }

// Concrete Products (Mac Theme)
public class MacButton : IButton { public string Render() => "Mac Button"; }
public class MacCheckbox : ICheckbox { public string Render() => "Mac Checkbox"; }

// Abstract Factory
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WindowsGUIFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacGUIFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Client Code
public class Application
{
    private IGUIFactory _factory;
    private IButton _button;
    private ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _factory = factory;
    }

    public void CreateUI()
    {
        _button = _factory.CreateButton();
        _checkbox = _factory.CreateCheckbox();
    }

    public void RenderUI()
    {
        Console.WriteLine(_button.Render());
        Console.WriteLine(_checkbox.Render());
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Application windowsApp = new Application(new WindowsGUIFactory());
        Application macApp = new Application(new MacGUIFactory());

        Console.WriteLine("Windows UI:");
        windowsApp.CreateUI();
        windowsApp.RenderUI();

        Console.WriteLine("\nMac UI:");
        macApp.CreateUI();
        macApp.RenderUI();
    }
}
```
#### 4. Builder

Intent: Separate the construction of a complex object from its representation so that the same construction process can create different representations.
Use Case: Creating complex objects step-by-step, where the construction process needs to be independent of the object's parts and assembly. Good for creating different variations of an object.
C# Example (Simplified Pizza Builder):

```C#
// Product: Pizza
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine($"Pizza with {Dough} dough, {Sauce} sauce, and {Topping} topping.");
    }
}

// Builder Interface
public interface IPizzaBuilder
{
    void Reset();
    void SetDough(string dough);
    void SetSauce(string sauce);
    void SetTopping(string topping);
    Pizza GetPizza();
}

// Concrete Builder
public class VeggiePizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void Reset() { _pizza = new Pizza(); }
    public void SetDough(string dough) { _pizza.Dough = dough; }
    public void SetSauce(string sauce) { _pizza.Sauce = sauce; }
    public void SetTopping(string topping) { _pizza.Topping = topping; }
    public Pizza GetPizza()
    {
        Pizza pizza = _pizza;
        Reset(); // Reset builder for next pizza
        return pizza;
    }
}

// Director (Optional, can be in Client)
public class PizzaDirector
{
    private IPizzaBuilder _builder;

    public PizzaDirector(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructVeggiePizza()
    {
        _builder.Reset();
        _builder.SetDough("Thin Crust");
        _builder.SetSauce("Marinara");
        _builder.SetTopping("Veggies");
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        var veggieBuilder = new VeggiePizzaBuilder();
        var director = new PizzaDirector(veggieBuilder);

        director.ConstructVeggiePizza();
        Pizza veggiePizza = veggieBuilder.GetPizza();
        veggiePizza.Display(); // Pizza with Thin Crust dough, Marinara sauce, and Veggies topping.
    }
}
```

#### 5. Prototype

Intent: Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
Use Case: When creating instances of classes is costly or complex, and you can create new objects by cloning or copying existing prototypes.   
C# Example (Simplified):   

```C#
// Prototype Interface (or abstract class implementing ICloneable)
public interface IPrototype : ICloneable
{
    string Name { get; set; }
}

// Concrete Prototype
public class ConcretePrototype : IPrototype
{
    public string Name { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone(); // Shallow copy - for deep copy, need more logic
    }

    public ConcretePrototype(string name)
    {
        Name = name;
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        ConcretePrototype prototype = new ConcretePrototype("Original");
        Console.WriteLine($"Prototype Name: {prototype.Name}");

        ConcretePrototype clone = (ConcretePrototype)prototype.Clone();
        clone.Name = "Clone"; // Modify the clone
        Console.WriteLine($"Clone Name: {clone.Name}");
        Console.WriteLine($"Original Prototype Name (unchanged): {prototype.Name}");
    }
}
```
### II. Structural Design Patterns
Structural patterns are concerned with how classes and objects are composed to form larger structures.

#### 6. Adapter

Intent: Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
Use Case: Integrating with legacy systems, third-party libraries with different interfaces, or when you want to reuse existing classes but their interfaces don't match your needs.
C# Example (Simplified Power Adapter):
```C#

// Target Interface (What client expects)
public interface IPowerOutlet
{
    void PlugIn();
}

// Adaptee (Incompatible interface, needs adaptation)
public class EuropeanSocket
{
    public void PlugIntoEuropeanSocket()
    {
        Console.WriteLine("Plugging into European socket.");
    }
}

// Adapter
public class EuropeanToUSAdapter : IPowerOutlet
{
    private EuropeanSocket _europeanSocket;

    public EuropeanToUSAdapter(EuropeanSocket europeanSocket)
    {
        _europeanSocket = europeanSocket;
    }

    public void PlugIn()
    {
        Console.WriteLine("Adapter converting to US standard...");
        _europeanSocket.PlugIntoEuropeanSocket(); // Adaptee's specific method
        Console.WriteLine("Plugged into US power outlet (via adapter).");
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        EuropeanSocket europeanSocket = new EuropeanSocket();
        EuropeanToUSAdapter adapter = new EuropeanToUSAdapter(europeanSocket);

        Console.WriteLine("Using US Power Outlet (via Adapter):");
        adapter.PlugIn();
    }
}
```
#### 7. Bridge

Intent: Decouple an abstraction from its implementation so that the two can vary independently.
Use Case: When you have class hierarchies for both abstraction and implementation, and you want to avoid tight coupling and allow them to evolve separately.   
C# Example (Simplified Shape and Drawing API Bridge):
```C#

// Abstraction Interface
public interface IShape
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
public class CircleShape : IShape
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

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        IShape vectorCircle = new CircleShape(1, 2, 5, new VectorDrawingAPI());
        IShape rasterCircle = new CircleShape(5, 7, 10, new RasterDrawingAPI());

        vectorCircle.Draw(); // Vector API: Drawing circle at (1,2) with radius 5
        rasterCircle.Draw(); // Raster API: Drawing circle at (5,7) with radius 10
    }
}
```
#### 8. Composite

Intent: Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
Use Case: Representing hierarchical structures like file systems, organizational charts, UI component trees, menus, etc.
C# Example (Simplified File System Directory Structure):
```C#

using System.Collections.Generic;

// Component Interface
public interface IComponent
{
    string Name { get; }
    void Display();
}

// Leaf: File
public class FileComponent : IComponent
{
    public string Name { get; }

    public FileComponent(string name)
    {
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {Name}");
    }
}

// Composite: Directory
public class DirectoryComponent : IComponent
{
    public string Name { get; }
    private List<IComponent> _children = new List<IComponent>();

    public DirectoryComponent(string name)
    {
        Name = name;
    }

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void Display()
    {
        Console.WriteLine($"Directory: {Name}");
        foreach (var component in _children)
        {
            component.Display(); // Recursively display children
        }
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        DirectoryComponent rootDir = new DirectoryComponent("Root");
        DirectoryComponent musicDir = new DirectoryComponent("Music");
        DirectoryComponent picturesDir = new DirectoryComponent("Pictures");

        FileComponent song1 = new FileComponent("song1.mp3");
        FileComponent song2 = new FileComponent("song2.mp3");
        FileComponent picture1 = new FileComponent("image1.jpg");

        musicDir.Add(song1);
        musicDir.Add(song2);
        picturesDir.Add(picture1);

        rootDir.Add(musicDir);
        rootDir.Add(picturesDir);

        rootDir.Display(); // Display the entire directory structure
    }
}
```
#### 9. Decorator

Intent: Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
Use Case: Adding features to objects dynamically, such as adding borders, scrollbars to UI components, or adding logging, caching to services.
C# Example (Simplified Coffee with Condiments Decorator):
```C#

// Component Interface
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";
    public double GetCost() => 1.00;
}

// Decorator Abstract Class
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee; // Wrapped component

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
}

// Concrete Decorators
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => base.GetDescription() + ", with Milk";
    public override double GetCost() => base.GetCost() + 0.30;
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => base.GetDescription() + ", with Sugar";
    public override double GetCost() => base.GetCost() + 0.10;
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - Cost: ${coffee.GetCost()}"); // Simple Coffee - Cost: $1

        ICoffee milkCoffee = new MilkDecorator(coffee);
        Console.WriteLine($"{milkCoffee.GetDescription()} - Cost: ${milkCoffee.GetCost()}"); // Simple Coffee, with Milk - Cost: $1.3

        ICoffee sugarMilkCoffee = new SugarDecorator(milkCoffee);
        Console.WriteLine($"{sugarMilkCoffee.GetDescription()} - Cost: ${sugarMilkCoffee.GetCost()}"); // Simple Coffee, with Milk, with Sugar - Cost: $1.4
    }
}
```
#### 10. Facade

Intent: Provide a simplified interface to a complex subsystem. Facade provides a higher-level interface that makes the subsystem easier to use.   
Use Case: Simplifying complex subsystems, hiding complexity from clients, providing a single entry point.
C# Example (Simplified Order Processing Facade):
```C#

// Subsystem Classes
public class InventoryService
{
    public bool CheckInventory(string productId) => true; // Simplified check
}

public class PaymentService
{
    public bool ProcessPayment(decimal amount, string paymentInfo) => true; // Simplified process
}

public class ShippingService
{
    public void ShipOrder(string orderId) => Console.WriteLine($"Order {orderId} shipped.");
}

// Facade
public class OrderFacade
{
    private InventoryService _inventoryService;
    private PaymentService _paymentService;
    private ShippingService _shippingService;

    public OrderFacade()
    {
        _inventoryService = new InventoryService();
        _paymentService = new PaymentService();
        _shippingService = new ShippingService();
    }

    public void PlaceOrder(string productId, int quantity, decimal price, string paymentInfo)
    {
        if (!_inventoryService.CheckInventory(productId))
        {
            Console.WriteLine($"Product {productId} out of stock.");
            return;
        }

        decimal totalAmount = price * quantity;
        if (!_paymentService.ProcessPayment(totalAmount, paymentInfo))
        {
            Console.WriteLine("Payment failed.");
            return;
        }

        string orderId = Guid.NewGuid().ToString(); // Generate order ID
        _shippingService.ShipOrder(orderId);
        Console.WriteLine($"Order {orderId} placed successfully.");
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        OrderFacade orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("Product123", 2, 25.00m, "credit_card_info"); // Simplified client call
    }
}
```
#### 11. Flyweight

Intent: Use sharing to support large numbers of fine-grained objects efficiently.
Use Case: When you need to create a large number of similar objects, especially when object creation is costly or memory-intensive (e.g., characters in a document editor, trees in a forest simulation). Often involves intrinsic and extrinsic state.
C# Example (Simplified Character Flyweight - Intrinsic state sharing):
```C#

using System.Collections.Generic;

// Flyweight Interface
public interface ICharacterFlyweight
{
    void Display(string fontStyle, int fontSize); // Extrinsic state passed in
}

// Concrete Flyweight
public class CharacterA : ICharacterFlyweight
{
    private char _character = 'A'; // Intrinsic state (shared)

    public void Display(string fontStyle, int fontSize)
    {
        Console.WriteLine($"Character: {_character}, Font Style: {fontStyle}, Font Size: {fontSize}");
    }
}

// Flyweight Factory
public class CharacterFlyweightFactory
{
    private Dictionary<char, ICharacterFlyweight> _flyweights = new Dictionary<char, ICharacterFlyweight>();

    public ICharacterFlyweight GetCharacterFlyweight(char character)
    {
        if (!_flyweights.ContainsKey(character))
        {
            switch (character)
            {
                case 'A': _flyweights['A'] = new CharacterA(); break;
                // Add cases for other characters if needed...
                default:
                    throw new ArgumentException($"Flyweight for character '{character}' not supported.");
            }
        }
        return _flyweights[character];
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        CharacterFlyweightFactory factory = new CharacterFlyweightFactory();

        ICharacterFlyweight charA1 = factory.GetCharacterFlyweight('A');
        ICharacterFlyweight charA2 = factory.GetCharacterFlyweight('A'); // Same instance reused

        Console.WriteLine($"Are charA1 and charA2 the same instance? {ReferenceEquals(charA1, charA2)}"); // True

        charA1.Display("Times New Roman", 12); // Extrinsic state passed in each call
        charA2.Display("Arial", 14);          // Extrinsic state can vary for the same flyweight
    }
}
```
#### 12. Proxy

Intent: Provide a surrogate or placeholder for another object to control access to it.
Use Case: Controlling access to resources (e.g., lazy loading, access control, logging, caching), remote proxies for distributed systems.
C# Example (Simplified Protection Proxy for sensitive resource access):

```C#

// Subject Interface
public interface ISubject
{
    void Request();
}

// Real Subject (Sensitive Resource)
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

// Proxy
public class ProtectionProxy : ISubject
{
    private RealSubject _realSubject;
    private bool _isAuthenticated;

    public ProtectionProxy(string username, string password)
    {
        // Simplified authentication for example
        if (username == "admin" && password == "password")
        {
            _isAuthenticated = true;
        }
    }

    public void Request()
    {
        if (_isAuthenticated)
        {
            if (_realSubject == null) // Lazy initialization of RealSubject
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request(); // Access to RealSubject only if authenticated
        }
        else
        {
            Console.WriteLine("Proxy: Access denied. Authentication required.");
        }
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Client: Accessing protected resource via Proxy (with valid credentials):");
        ProtectionProxy proxy = new ProtectionProxy("admin", "password");
        proxy.Request(); // Access granted

        Console.WriteLine("\nClient: Accessing protected resource via Proxy (with invalid credentials):");
        ProtectionProxy invalidProxy = new ProtectionProxy("user", "wrongpass");
        invalidProxy.Request(); // Access denied
    }
}
```
#### III. Behavioral Design Patterns
Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects.

(These were covered in detail in your previous questions, so I'll provide more concise examples here).

#### 13. Chain of Responsibility

Intent: Avoid coupling the sender of a request to its receiver by giving multiple objects a chance to handle the request.
Use Case: Request processing pipelines, event handling, help systems.   
C# Example (Simplified Handler Chain for requests): (Example from previous response is more detailed)

```C#

// Handler Interface
public abstract class Handler
{
    private Handler _nextHandler;
    public Handler SetNext(Handler handler) { _nextHandler = handler; return handler; }
    public abstract void HandleRequest(int request);
    protected void PassToNext(int request) => _nextHandler?.HandleRequest(request);
}

// Concrete Handlers
public class ConcreteHandler1 : Handler { public override void HandleRequest(int request) { if (request <= 10) Console.WriteLine($"Handler1 handled request {request}"); else PassToNext(request); } }
public class ConcreteHandler2 : Handler { public override void HandleRequest(int request) { if (request > 10 && request <= 20) Console.WriteLine($"Handler2 handled request {request}"); else PassToNext(request); } }

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        var h1 = new ConcreteHandler1();
        var h2 = new ConcreteHandler2();
        h1.SetNext(h2);

        h1.HandleRequest(5);  // Handler1
        h1.HandleRequest(15); // Handler2
        h1.HandleRequest(25); // No handler (end of chain)
    }
}
```
#### 14. Command

Intent: Encapsulate a request as an object, allowing parameterization, queuing, and undoable operations.
Use Case: Undo/redo functionality, menu systems, macro recording, transaction processing.   
C# Example (Simplified Command for button actions): (Example from previous response is more detailed)

```C#

// Command Interface
public interface ICommand { void Execute(); void Undo(); }

// Receiver
public class Receiver { public void ActionA() => Console.WriteLine("Receiver: Action A"); public void ActionB() => Console.WriteLine("Receiver: Action B"); }

// Concrete Commands
public class ConcreteCommandA : ICommand { private Receiver _receiver; public ConcreteCommandA(Receiver receiver) => _receiver = receiver; public void Execute() => _receiver.ActionA(); public void Undo() => Console.WriteLine("Undo Command A"); }
public class ConcreteCommandB : ICommand { private Receiver _receiver; public ConcreteCommandB(Receiver receiver) => _receiver = receiver; public void Execute() => _receiver.ActionB(); public void Undo() => Console.WriteLine("Undo Command B"); }

// Invoker
public class Invoker
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void ExecuteCommand() => _command.Execute();
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        var receiver = new Receiver();
        var invoker = new Invoker();

        invoker.SetCommand(new ConcreteCommandA(receiver));
        invoker.ExecuteCommand(); // Receiver: Action A

        invoker.SetCommand(new ConcreteCommandB(receiver));
        invoker.ExecuteCommand(); // Receiver: Action B
    }
}
```
#### 15. Interpreter

Intent: Given a language, define a representation for its grammar along with an interpreter.
Use Case: Parsing and evaluating domain-specific languages (DSLs), rule engines, mathematical expressions.
C# Example (Simplified Expression Interpreter - Boolean): (Example from previous response is more detailed)

```C#

// Expression Interface
public interface IExpression { bool Interpret(Context context); }
// Context (Simplified - for variable lookup)
public class Context { private Dictionary<string, bool> vars = new Dictionary<string, bool>(); public void SetVar(string var, bool value) => vars[var] = value; public bool GetVar(string var) => vars.ContainsKey(var) ? vars[var] : false; }
// Terminal Expression
public class Variable : IExpression { string name; public Variable(string name) => this.name = name; public bool Interpret(Context context) => context.GetVar(name); }
// Non-Terminal Expression
public class AndExpression : IExpression { IExpression expr1, expr2; public AndExpression(IExpression expr1, IExpression expr2) { this.expr1 = expr1; this.expr2 = expr2; } public bool Interpret(Context context) => expr1.Interpret(context) && expr2.Interpret(context); }

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Context context = new Context();
        Variable x = new Variable("x");
        Variable y = new Variable("y");
        IExpression expression = new AndExpression(x, y); // x AND y

        context.SetVar("x", true);
        context.SetVar("y", true);
        Console.WriteLine($"x=true, y=true: {expression.Interpret(context)}"); // True

        context.SetVar("y", false);
        Console.WriteLine($"x=true, y=false: {expression.Interpret(context)}"); // False
    }
}
```
#### 16. Iterator

Intent: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
Use Case: Traversing collections, lists, trees without knowing their internal structure. C# foreach and IEnumerable/IEnumerator are built-in implementations.
C# Example (Using built-in IEnumerable and yield return):

```C#

using System.Collections;
using System.Collections.Generic;

// Aggregate Collection
public class NumberCollection : IEnumerable<int>
{
    private List<int> _numbers = new List<int> { 1, 2, 3, 4, 5 };

    public IEnumerator<int> GetEnumerator()
    {
        foreach (int number in _numbers)
        {
            yield return number; // Yield return makes this an iterator
        }
    }

    IEnumerator IEnumerable.GetEnumerator() // Non-generic IEnumerator for older interfaces
    {
        return GetEnumerator();
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        var numbers = new NumberCollection();

        Console.WriteLine("Iterating through numbers:");
        foreach (int num in numbers) // Using foreach, implicitly uses the iterator
        {
            Console.WriteLine(num);
        }
    }
}
```
#### 17. Mediator

Intent: Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly.   
Use Case: Managing complex interactions between UI components, chat applications, workflow control.
C# Example (Simplified Chat Room Mediator): (Example from previous response is more detailed)

```C#

// Mediator Interface
public interface IChatRoomMediator { void SendMessage(string message, User user); }
// Colleague Class
public abstract class User { protected IChatRoomMediator mediator; public string Name { get; } public User(IChatRoomMediator mediator, string name) { this.mediator = mediator; Name = name; } public abstract void Send(string message); public abstract void Receive(string message, User sender); }

// Concrete Mediator
public class ChatRoom : IChatRoomMediator
{
    private List<User> users = new List<User>();
    public void Join(User user) { users.Add(user); }
    public void SendMessage(string message, User user) { foreach (var u in users) if (u != user) u.Receive(message, user); } }
// Concrete Colleagues
public class ConcreteUser : User { public ConcreteUser(IChatRoomMediator mediator, string name) : base(mediator, name) { } public override void Send(string message) => mediator.SendMessage(message, this); public override void Receive(string message, User sender) => Console.WriteLine($"{Name} received from {sender.Name}: {message}"); }

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        IChatRoomMediator mediator = new ChatRoom();
        User user1 = new ConcreteUser(mediator, "Alice");
        User user2 = new ConcreteUser(mediator, "Bob");
        User user3 = new ConcreteUser(mediator, "Charlie");

        mediator.Join(user1);
        mediator.Join(user2);
        mediator.Join(user3);

        user1.Send("Hello everyone!"); // Alice sends message, mediated through ChatRoom
    }
}
```
#### 18. Memento

Intent: Capture and externalize an object's internal state so that the object can be restored to this state later, without violating encapsulation.
Use Case: Undo/redo, transaction rollback, application state persistence.
C# Example (Simplified Editor Memento for text state): (Example from previous response is more detailed)

```C#

// Originator
public class Editor
{
    private string _text;
    public void SetText(string text) { _text = text; }
    public string GetText() => _text;
    public Memento SaveState() => new Memento(_text);
    public void RestoreState(Memento memento) => _text = memento.GetState();
}
// Memento
public class Memento
{
    private string _state;
    public Memento(string state) => _state = state;
    public string GetState() => _state;
}
// Caretaker (Manages history of Mementos)
public class History
{
    private Stack<Memento> _history = new Stack<Memento>();
    public void Push(Memento memento) => _history.Push(memento);
    public Memento Pop() => _history.Count > 0 ? _history.Pop() : null;
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        Editor editor = new Editor();
        History history = new History();

        editor.SetText("First state");
        history.Push(editor.SaveState()); // Save state

        editor.SetText("Second state");
        history.Push(editor.SaveState()); // Save state

        editor.SetText("Third state");
        Console.WriteLine($"Current state: {editor.GetText()}"); // Third state

        editor.RestoreState(history.Pop()); // Undo to second state
        Console.WriteLine($"Restored to state: {editor.GetText()}"); // Second state

        editor.RestoreState(history.Pop()); // Undo to first state
        Console.WriteLine($"Restored to state: {editor.GetText()}"); // First state
    }
}
```
#### 19. Observer

Intent: Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. C# Events are a built-in implementation.   
Use Case: UI updates based on data changes, event-driven systems, publish-subscribe mechanisms. C# Events and Delegates are the standard way to implement this in C#.
C# Example (Using C# Events):

```C#

// Subject
public class StockTicker
{
    public event EventHandler<StockChangedEventArgs> StockPriceChanged; // C# Event

    private decimal _stockPrice;
    public decimal StockPrice
    {
        get => _stockPrice;
        set
        {
            if (_stockPrice != value)
            {
                _stockPrice = value;
                OnStockPriceChanged(new StockChangedEventArgs { NewPrice = _stockPrice }); // Raise event
            }
        }
    }

    protected virtual void OnStockPriceChanged(StockChangedEventArgs e)
    {
        StockPriceChanged?.Invoke(this, e); // Safe invocation of event handlers
    }
}

public class StockChangedEventArgs : EventArgs
{
    public decimal NewPrice { get; set; }
}

// Observer
public class PriceDisplay
{
    public void UpdatePrice(object sender, StockChangedEventArgs e)
    {
        Console.WriteLine($"Price Display: Stock price changed to ${e.NewPrice}");
    }
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        StockTicker ticker = new StockTicker();
        PriceDisplay display1 = new PriceDisplay();
        PriceDisplay display2 = new PriceDisplay();

        // Subscribe observers to the event
        ticker.StockPriceChanged += display1.UpdatePrice;
        ticker.StockPriceChanged += display2.UpdatePrice;

        ticker.StockPrice = 150.00m; // Trigger price change, observers notified
        ticker.StockPrice = 152.50m; // Another price change
    }
}
```
#### 20. State

Intent: Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.   
Use Case: Managing object behavior that depends on state, state machines, workflows, UI element states.
C# Example (Simplified TCP Connection States): (Example from previous response is more detailed)

```C#

// State Interface
public interface IConnectionState { void Open(ConnectionContext context); void Close(ConnectionContext context); void SendData(ConnectionContext context, string data); }
// Context
public class ConnectionContext { public IConnectionState State { get; set; } public void Open() => State.Open(this); public void Close() => State.Close(this); public void SendData(string data) => State.SendData(this, data); public void ChangeState(IConnectionState newState) { State = newState; Console.WriteLine($"Context: State changed to {newState.GetType().Name}"); } }
// Concrete States
public class ClosedState : IConnectionState { public void Open(ConnectionContext context) => context.ChangeState(new OpenedState()); public void Close(ConnectionContext context) => Console.WriteLine("Connection already closed."); public void SendData(ConnectionContext context, string data) => Console.WriteLine("Cannot send data in closed state."); }
public class OpenedState : IConnectionState { public void Open(ConnectionContext context) => Console.WriteLine("Connection already opened."); public void Close(ConnectionContext context) => context.ChangeState(new ClosedState()); public void SendData(ConnectionContext context, string data) => Console.WriteLine($"Sending data: {data}"); }

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        ConnectionContext context = new ConnectionContext { State = new ClosedState() }; // Initial state: Closed

        context.Open(); // State changes to Opened
        context.SendData("Hello"); // Sending data: Hello
        context.SendData("World"); // Sending data: World
        context.Close(); // State changes to Closed
        context.SendData("Data after close"); // Cannot send data in closed state.
    }
}
```
#### 21. Strategy

Intent: Define a family of algorithms, encapsulate each one, and make them interchangeable.
Use Case: Selecting algorithms at runtime, variations of sorting, payment processing, validation.
C# Example (Simplified Sorting Strategies): (Example from previous response is more detailed)

```C#

// Strategy Interface
public interface ISortStrategy { void Sort(List<int> list); }
// Concrete Strategies
public class BubbleSortStrategy : ISortStrategy { public void Sort(List<int> list) => Console.WriteLine("Sorting using Bubble Sort"); /* Bubble sort implementation */ }
public class QuickSortStrategy : ISortStrategy { public void Sort(List<int> list) => Console.WriteLine("Sorting using Quick Sort"); /* Quick sort implementation */ }
// Context
public class Sorter
{
    private ISortStrategy _strategy;
    public void SetStrategy(ISortStrategy strategy) => _strategy = strategy;
    public void SortList(List<int> list) => _strategy.Sort(list);
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        var sorter = new Sorter();
        var data = new List<int> { 5, 2, 8, 1, 9 };

        sorter.SetStrategy(new BubbleSortStrategy());
        sorter.SortList(data); // Sorting using Bubble Sort

        sorter.SetStrategy(new QuickSortStrategy());
        sorter.SortList(data); // Sorting using Quick Sort
    }
}
```
#### 22. Template Method

Intent: Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
Use Case: Creating reusable base classes with common algorithm structures, subclasses customize specific steps (e.g., report generation, document processing).
C# Example (Simplified Data Processing Template):

```C#

// Abstract Class with Template Method
public abstract class DataProcessor
{
    // Template Method - defines algorithm skeleton
    public void ProcessData()
    {
        ReadData();
        ProcessItemData(); // Abstract step
        WriteData();
    }

    protected abstract void ProcessItemData(); // Abstract step - subclasses implement

    protected virtual void ReadData() => Console.WriteLine("DataProcessor: Reading data from source."); // Concrete step (can be overridden)
    protected virtual void WriteData() => Console.WriteLine("DataProcessor: Writing processed data to destination."); // Concrete step (can be overridden)
}

// Concrete Subclasses
public class CSVProcessor : DataProcessor
{
    protected override void ProcessItemData() => Console.WriteLine("CSVProcessor: Processing data in CSV format.");
}

public class XMLProcessor : DataProcessor
{
    protected override void ProcessItemData() => Console.WriteLine("XMLProcessor: Processing data in XML format.");
}

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        DataProcessor csvProcessor = new CSVProcessor();
        DataProcessor xmlProcessor = new XMLProcessor();

        Console.WriteLine("Processing CSV Data:");
        csvProcessor.ProcessData();

        Console.WriteLine("\nProcessing XML Data:");
        xmlProcessor.ProcessData();
    }
}
```
#### 23. Visitor

Intent: Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.   
Use Case: Adding new operations to complex object structures (like syntax trees, document structures) without modifying the structure classes themselves (e.g., printing, type-checking, code generation).
C# Example (Simplified Document Structure and Visitors - Print and HTML Export): (Example from previous response is more detailed)

```C#

// Element Interface
public interface IElement { void Accept(IVisitor visitor); }
// Concrete Elements
public class Header : IElement { public string Text { get; set; } public Header(string text) => Text = text; public void Accept(IVisitor visitor) => visitor.VisitHeader(this); }
public class Paragraph : IElement { public string Text { get; set; } public Paragraph(string text) => Text = text; public void Accept(IVisitor visitor) => visitor.VisitParagraph(this); }

// Visitor Interface
public interface IVisitor
{
    void VisitHeader(Header header);
    void VisitParagraph(Paragraph paragraph);
}
// Concrete Visitors
public class PrintVisitor : IVisitor { public void VisitHeader(Header header) => Console.WriteLine($"PRINT: Header - {header.Text}"); public void VisitParagraph(Paragraph paragraph) => Console.WriteLine($"PRINT: Paragraph - {paragraph.Text}"); }
public class HTMLExportVisitor : IVisitor { public void VisitHeader(Header header) => Console.WriteLine($"HTML: <header>{header.Text}</header>"); public void VisitParagraph(Paragraph paragraph) => Console.WriteLine($"HTML: <p>{paragraph.Text}</p>"); }

// Usage
public class Client
{
    public static void Main(string[] args)
    {
        IElement[] document = { new Header("Document Title"), new Paragraph("This is the first paragraph.") };

        PrintVisitor printVisitor = new PrintVisitor();
        HTMLExportVisitor htmlVisitor = new HTMLExportVisitor();

        Console.WriteLine("Printing Document:");
        foreach (var element in document) element.Accept(printVisitor);

        Console.WriteLine("\nExporting to HTML:");
        foreach (var element in document) element.Accept(htmlVisitor);
    }
}
```
This list provides a good starting point for understanding and using design patterns in C#. Remember that these are simplified examples to illustrate the core ideas. Real-world implementations might be more complex and tailored to specific needs.  It's highly recommended to study each pattern in more depth as you encounter situations where they might be applicable. There are many excellent books and online resources (like those I mentioned in our earlier conversations) that provide more detailed explanations and use cases.



Let's explore the SOLID principles with C# examples.  SOLID is an acronym coined by Robert C. Martin (Uncle Bob) that represents five key principles of object-oriented design.  Adhering to these principles helps create maintainable, flexible, and scalable software.

Single Responsibility Principle (SRP)
Open/Closed Principle (OCP)
Liskov Substitution Principle (LSP)
Interface Segregation Principle (ISP)
Dependency Inversion Principle (DIP)   

#### 1. Single Responsibility Principle (SRP)

A class should have one, and only one, reason to change.  This means that each class should have a single responsibility or job.

```C#

// Bad example - Two responsibilities (reporting and persistence)
public class Order
{
    public void CalculateTotal() { /* ... */ }
    public void SaveToDatabase() { /* ... */ }
}

// Good example - Separated responsibilities
public class Order
{
    public void CalculateTotal() { /* ... */ }
}

public class OrderRepository
{
    public void Save(Order order) { /* ... */ }
}
```
#### 2. Open/Closed Principle (OCP)

Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification.  This means you should be able to add new functionality without changing existing code.  Abstract classes and interfaces are key to this.   

```C#

// Bad example - Modifying the class to add new shape types
public class Shape
{
    public string Type { get; set; } // "Rectangle", "Circle"
    public void Draw()
    {
        if (Type == "Rectangle") { /* ... */ }
        else if (Type == "Circle") { /* ... */ }
    }
}

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
```
#### 3. Liskov Substitution Principle (LSP)

Objects of a derived class should be substitutable for objects of their base class without altering any of the desirable properties of that program.  Essentially, if you have a base class, any derived class should be usable wherever the base class is used.

```C#

public class Bird
{
    public virtual void Fly() { /* ... */ }
}

public class Eagle : Bird
{
    public override void Fly() { /* ... */ }
}

public class Ostrich : Bird // Ostrich can't fly!
{
    // Violates LSP - Can't substitute Ostrich where Bird is expected to fly.
    // One solution is to throw an exception or not override Fly at all.
    // A better solution might be to rethink the inheritance hierarchy (Bird and FlyingBird).
    // public override void Fly() { throw new NotImplementedException(); } 
}

// Example usage
public void MakeBirdFly(Bird bird)
{
    bird.Fly();
}

Eagle eagle = new Eagle();
MakeBirdFly(eagle); // Works fine

Ostrich ostrich = new Ostrich();
// MakeBirdFly(ostrich); // Breaks the program because Ostrich can't fly.
```

#### 4. Interface Segregation Principle (ISP)

Many specific interfaces are better than one general-purpose interface.  Clients should not be forced to depend on methods they don't use.  This principle is about keeping interfaces small and focused.   

```C#

// Bad example - Fat interface
public interface IPrint
{
    void Print();
    void Scan();
    void Fax();
}

// Good example - Segregated interfaces
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFax
{
    void Fax();
}

public class MultiFunctionPrinter : IPrinter, IScanner, IFax { /* ... */ }
public class SimplePrinter : IPrinter { /* ... */ } // Doesn't need to implement Scan or Fax
```

#### 5. Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.   

```C#

// Bad example - High-level depends on low-level
public class Button
{
    private Lamp _lamp = new Lamp(); // Direct dependency

    public void Press()
    {
        _lamp.TurnOn();
    }
}

public class Lamp
{
    public void TurnOn() { /* ... */ }
}

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
```
// Now the Button can work with any ISwitchable device!

These examples illustrate the core concepts of the SOLID principles.  Applying them requires careful consideration of your design, but the benefits in terms of maintainability and flexibility are significant.  Remember that these are principles, not rigid rules. There might be situations where strict adherence isn't the most practical approach.  The key is understanding the intent behind each principle and applying them judiciously.
