namespace designpatterns.dp;

// Product (the complex object we're building)
public class Pizza
{
    public string Crust { get; set; }
    public string Sauce { get; set; }
    public List<string> Toppings { get; set; } = new List<string>();
    public string Size { get; set; }

    public override string ToString()
    {
        return $"Pizza: {Size}, {Crust} Crust, {Sauce} Sauce, Toppings: {string.Join(", ", Toppings)}";
    }
}

// Abstract Builder interface
public interface IPizzaBuilder
{
    void BuildCrust(string crust);
    void BuildSauce(string sauce);
    void AddTopping(string topping);
    void SetSize(string size);
    Pizza GetPizza();
}

// Concrete Builder (for a specific type of pizza, e.g., Pepperoni)
public class PepperoniPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void BuildCrust(string crust)
    {
        _pizza.Crust = crust;
    }

    public void BuildSauce(string sauce)
    {
        _pizza.Sauce = sauce;
    }

    public void AddTopping(string topping)
    {
        _pizza.Toppings.Add(topping);
    }

    public void SetSize(string size)
    {
        _pizza.Size = size;
    }

    public Pizza GetPizza()
    {
        Pizza pizza = _pizza;
        _pizza = new Pizza(); // Reset for the next pizza
        return pizza;
    }
}

// Director (orchestrates the building process)
public class PizzaDirector
{
    private IPizzaBuilder _builder;

    public PizzaDirector(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructPepperoniPizza()
    {
        _builder.BuildCrust("Thin");
        _builder.BuildSauce("Tomato");
        _builder.AddTopping("Pepperoni");
        _builder.AddTopping("Cheese");
        _builder.SetSize("Large");
    }

    public void ConstructCustomPizza(string crust, string sauce, List<string> toppings, string size)
    {
        _builder.BuildCrust(crust);
        _builder.BuildSauce(sauce);
        foreach (var topping in toppings)
        {
            _builder.AddTopping(topping);
        }
        _builder.SetSize(size);
    }
}

