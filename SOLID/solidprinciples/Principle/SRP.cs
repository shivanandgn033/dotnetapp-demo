namespace solidprinciples.Principle;
// Single Responsibility Principle (SRP)

// A class should have one, and only one, reason to change. 
// This means that each class should have a single responsibility or job.

// Bad example - Two responsibilities (reporting and persistence)
// public class Order
// {
//     public void CalculateTotal() { /* ... */ }
//     public void SaveToDatabase() { /* ... */ }
// }

//................................................................................
// Good example - Separated responsibilities
public class Order {
  public void CalculateTotal() {
    /* ... */
  }
}

public class OrderRepository {
  public void Save(Order order) {
    /* ... */
  }
}