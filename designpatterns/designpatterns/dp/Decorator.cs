namespace designpatterns.dp;

//decorator desgign patter in c sharp 
// Component Interface
public interface ICoffee {
  string GetDescription();
  double GetCost();
}

// Concrete Component
public class SimpleCoffee: ICoffee {
  public string GetDescription() =>"Simple Coffee";
  public double GetCost() =>1.00;
}

// Decorator Abstract Class
public abstract class CoffeeDecorator: ICoffee {
  protected ICoffee _coffee; // Wrapped component

  public CoffeeDecorator(ICoffee coffee) {
    _coffee = coffee;
  }

  public virtual string GetDescription() =>_coffee.GetDescription();
  public virtual double GetCost() =>_coffee.GetCost();
}

// Concrete Decorators
public class MilkDecorator: CoffeeDecorator {
  public MilkDecorator(ICoffee coffee) : base(coffee) {}

  public override string GetDescription() =>base.GetDescription() + ", with Milk";
  public override double GetCost() =>base.GetCost() + 0.30;
}

public class SugarDecorator: CoffeeDecorator {
  public SugarDecorator(ICoffee coffee) : base(coffee) {}

  public override string GetDescription() =>base.GetDescription() + ", with Sugar";
  public override double GetCost() =>base.GetCost() + 0.10;
}