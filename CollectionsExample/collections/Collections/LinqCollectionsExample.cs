using System;
using System.Collections.Generic;
using System.Linq;

namespace collections;

public class LinqCollectionsExample
{
     public static void LinqCollectionsExampleMethod()
     {
               // Sample Data
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 30, City = "New York" },
            new Person { Name = "Bob", Age = 25, City = "London" },
            new Person { Name = "Charlie", Age = 35, City = "New York" },
            new Person { Name = "David", Age = 28, City = "Paris" },
            new Person { Name = "Eve", Age = 32, City = "London" }
        };

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1. Filtering (Where)
        var adults = people.Where(p => p.Age >= 30);
        Console.WriteLine("Adults:");
        foreach (var person in adults)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, {person.City}");
        }

        // 2. Projection (Select)
        var names = people.Select(p => p.Name);
        Console.WriteLine("\nNames:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        // 3. Ordering (OrderBy, OrderByDescending)
        var sortedPeople = people.OrderBy(p => p.Age);
        Console.WriteLine("\nPeople sorted by age:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }

        // 4. Grouping (GroupBy)
        var peopleByCity = people.GroupBy(p => p.City);
        Console.WriteLine("\nPeople grouped by city:");
        foreach (var group in peopleByCity)
        {
            Console.WriteLine($"City: {group.Key}");
            foreach (var person in group)
            {
                Console.WriteLine($"  {person.Name}, {person.Age}");
            }
        }

        // 5. Aggregation (Count, Sum, Average, Min, Max)
        int count = numbers.Count(n => n % 2 == 0);
        int sum = numbers.Sum();
        double average = numbers.Average();
        int min = numbers.Min();
        int max = numbers.Max();

        Console.WriteLine($"\nEven number count: {count}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");

        // 6. First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
        var firstAdult = people.FirstOrDefault(p => p.Age >= 30);
        var singlePerson = people.SingleOrDefault(p => p.Name == "Bob"); // returns null if multiple or none match
        Console.WriteLine($"\nFirst adult: {firstAdult?.Name}");
        Console.WriteLine($"Single person named Bob: {singlePerson?.Name}");

        // 7. Any, All, Contains
        bool anyAdults = people.Any(p => p.Age >= 30);
        bool allAdults = people.All(p => p.Age >= 18);
        bool containsFive = numbers.Contains(5);

        Console.WriteLine($"\nAny adults: {anyAdults}");
        Console.WriteLine($"All adults: {allAdults}");
        Console.WriteLine($"Contains 5: {containsFive}");

        // 8. SelectMany (Flattening sequences)
        List<List<int>> listOfLists = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 }
        };
        var flattenedList = listOfLists.SelectMany(list => list);
        Console.WriteLine("\nFlattened List");
        foreach(var item in flattenedList)
        {
            Console.WriteLine(item);
        }
     }
}

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
