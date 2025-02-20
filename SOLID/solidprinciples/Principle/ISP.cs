namespace solidprinciples.Principle;

 // Interface Segregation Principle (ISP)

 // Many specific interfaces are better than one general-purpose interface. 
 // Clients should not be forced to depend on methods they don't use. 
 // This principle is about keeping interfaces small and focused

// Bad example - Fat interface
// public interface IPrint
// {
//     void Print();
//     void Scan();
//     void Fax();
// }

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

public class MultiFunctionPrinter : IPrinter, IScanner, IFax { 
   
   public void Print()
    {
        Console.WriteLine("Printer");
    }
   public void Scan()
    {
        Console.WriteLine("Scanner");
    }
    public void Fax()
    {
       Console.WriteLine("Fax");
    }
    }
public class SimplePrinter : IPrinter { 
   public void Print()
    {
        Console.WriteLine("Printer");
    }
    } // Doesn't need to implement Scan or Fax