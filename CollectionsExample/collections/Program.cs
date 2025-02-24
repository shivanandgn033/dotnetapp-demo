using System;
using System.Collections.Generic;

        // 1. List<T> (Dynamic Array)
        // List<T>:
        // Represents a dynamically sized array.
        // Allows you to add, remove, and access elements by index.
        // Efficient for sequential access.

        List<string> names = new List<string>();
        names.Add("Alice");
        names.Add("Bob");
        names.Add("Charlie");

        Console.WriteLine("List:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine($"Name at index 1: {names[1]}"); //Access by index.
        names.Remove("Bob"); //Remove an element.
        Console.WriteLine($"List Count after removing Bob: {names.Count}");

        // 2. Dictionary<TKey, TValue> (Key-Value Pairs)
        // Dictionary<TKey, TValue>:
        // Stores key-value pairs.
        // Provides fast lookups based on keys.
        // Useful for mapping data.

        Dictionary<string, int> ages = new Dictionary<string, int>();
        ages["Alice"] = 30;
        ages["Charlie"] = 35;

        Console.WriteLine("\nDictionary:");
        foreach (var pair in ages)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        Console.WriteLine($"Alice's age: {ages["Alice"]}"); //Access by Key.

        if (ages.ContainsKey("Bob"))
        {
            Console.WriteLine("Bob's age found");
        }
        else
        {
            Console.WriteLine("Bob's age not found");
        }

         // 3. HashSet<T> (Unique Values)
         // HashSet<T>:
         // Stores unique elements.
         // Efficient for checking if an element exists.
         // Useful for removing duplicates.
        HashSet<int> numbers = new HashSet<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(2); // Duplicate, will be ignored

        Console.WriteLine("\nHashSet:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine($"HashSet contains 2: {numbers.Contains(2)}");

        // 4. Queue<T> (FIFO - First-In, First-Out)
        // Queue<T>:
        // Implements a First-In, First-Out (FIFO) data structure.
        // Elements are added to the back and removed from the front.
        // Used in scenarios like task scheduling.
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        Console.WriteLine("\nQueue:");
        while (queue.Count > 0)
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }

        // 5. Stack<T> (LIFO - Last-In, First-Out)
        // Stack<T>:
        // Implements a Last-In, First-Out (LIFO) data structure.
        // Elements are added and removed from the top.
        // Used in scenarios like undo/redo functionality.
        Stack<int> stack = new Stack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("\nStack:");
        while (stack.Count > 0)
        {
            Console.WriteLine($"Popped: {stack.Pop()}");
        }

        // 6. LinkedList<T> (Doubly Linked List)
        // LinkedList<T>:
        // A doubly linked list, meaning each element holds a reference to the next and previous element.
        // Efficient for inserting and removing elements in the middle of the list.
        // Less efficient for random access than a List<T>.

        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("apple");
        linkedList.AddLast("banana");
        linkedList.AddFirst("orange");

        Console.WriteLine("\nLinkedList:");
        foreach (var fruit in linkedList)
        {
            Console.WriteLine(fruit);
        }

       










