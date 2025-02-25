using System;
using System.Collections.Generic;
using System.Linq;

namespace collections;

public class EnumerableQueryableExample
{

    public static void EnumerableQueryableExampleMethod()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // IEnumerable Example (In-memory filtering)
        IEnumerable<int> evenNumbersEnumerable = numbers.Where(n => n % 2 == 0);

        Console.WriteLine("IEnumerable (Even Numbers):");
        foreach (int number in evenNumbersEnumerable)
        {
            Console.WriteLine(number);
        }

        // IQueryable Example (Simulating a database query)
        // In a real-world scenario, IQueryable would be used with a database provider (e.g., Entity Framework)
        // For this example, we'll use AsQueryable() to simulate a database query on an in-memory list.
        IQueryable<int> numbersQueryable = numbers.AsQueryable();

        IQueryable<int> evenNumbersQueryable = numbersQueryable.Where(n => n % 2 == 0);
        IQueryable<int> greaterThanFiveQueryable = evenNumbersQueryable.Where(n => n > 5);

        // The query is only executed when we iterate over the IQueryable.
        Console.WriteLine("\nIQueryable (Even Numbers Greater Than 5):");
        foreach (int number in greaterThanFiveQueryable)
        {
            Console.WriteLine(number);
        }

        //Demonstrating deferred execution with IQueryable.
        numbers.Add(12);

        Console.WriteLine("\nIQueryable (Even Numbers Greater Than 5) after adding 12:");
        foreach (int number in greaterThanFiveQueryable)
        {
            Console.WriteLine(number);
        }
    }

}
