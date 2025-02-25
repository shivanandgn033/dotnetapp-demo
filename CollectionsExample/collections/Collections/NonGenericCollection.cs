using System;
using System.Collections;

namespace collections;

public class NonGenericCollection
{
    public static void NonGenericCollectionMethod()
    {
        // 1. ArrayList (Dynamically resizable array, non-generic)
        ArrayList arrayList = new ArrayList();
        arrayList.Add(10);
        arrayList.Add("Hello");
        arrayList.Add(true);

        Console.WriteLine("ArrayList:");
        foreach (object item in arrayList)
        {
            Console.WriteLine(item);
        }

        arrayList.Remove("Hello");
        Console.WriteLine($"ArrayList Count after removing 'Hello': {arrayList.Count}");
        Console.WriteLine($"ArrayList[0]: {arrayList[0]}");

        // 2. Hashtable (Key-value pairs, non-generic)
        Hashtable hashtable = new Hashtable();
        hashtable["Name"] = "John Doe";
        hashtable["Age"] = 30;
        hashtable["IsEmployed"] = true;

        Console.WriteLine("\nHashtable:");
        foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        Console.WriteLine($"Name: {hashtable["Name"]}");

        // 3. Queue (FIFO, non-generic)
        Queue queue = new Queue();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        Console.WriteLine("\nQueue:");
        while (queue.Count > 0)
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }

        // 4. Stack (LIFO, non-generic)
        Stack stack = new Stack();
        stack.Push(100);
        stack.Push(200);
        stack.Push(300);

        Console.WriteLine("\nStack:");
        while (stack.Count > 0)
        {
            Console.WriteLine($"Popped: {stack.Pop()}");
        }

        // 5. BitArray (Array of bit values)
        BitArray bits1 = new BitArray(new bool[] { true, false, true, false });
        BitArray bits2 = new BitArray(new bool[] { false, true, false, true });

        Console.WriteLine("\nBitArray:");
        Console.WriteLine("Bits1:");
        foreach (bool bit in bits1)
        {
            Console.Write(bit ? "1" : "0");
        }
        Console.WriteLine();
        Console.WriteLine("Bits2:");
        foreach (bool bit in bits2)
        {
            Console.Write(bit ? "1" : "0");
        }
        Console.WriteLine();
        bits1.And(bits2);
        Console.WriteLine("bits1 AND bits2:");
        foreach (bool bit in bits1)
        {
            Console.Write(bit ? "1" : "0");
        }
        Console.WriteLine();
    }

}


// Key Concepts and Explanations:

// System.Collections Namespace:
// This namespace contains older, non-generic collection classes.
// These collections store objects of type object, meaning they can hold any data type.
// However, this lack of type safety can lead to runtime errors (e.g., InvalidCastException).
// It is generally recommended to use the generic collections in System.Collections.Generic for better type safety and performance.
// ArrayList:
// A dynamically resizable array that can hold objects of any type.
// Less performant than List<T> (generic) due to boxing and unboxing.
// Hashtable:
// A key-value pair collection similar to Dictionary<TKey, TValue>.
// Also less performant than Dictionary<TKey, TValue> due to boxing/unboxing.
// Queue:
// Implements a FIFO (First-In, First-Out) data structure.
// Elements are added to the back and removed from the front.
// Stack:
// Implements a LIFO (Last-In, First-Out) data structure.
// Elements are added and removed from the top.
// BitArray:
// An array of bit values (true/false, or 1/0).
// Useful for efficient storage and manipulation of bit flags.
// Allows bitwise operations (AND, OR, XOR, NOT).
// Important Considerations:

// Generics vs. Non-Generics:
// In modern C# development, it's strongly recommended to use the generic collections in System.Collections.Generic.
// Generic collections provide type safety, improved performance, and reduced code complexity.
// Boxing/Unboxing:
// The System.Collections classes use object, which means value types (like int, bool) are boxed (converted to object) when added and unboxed (converted back to their original type) when retrieved.
// This boxing/unboxing process can have a performance impact, especially in loops or frequently used collections.
// This example gives you a basic understanding of the non-generic collections. For most modern C# applications, favor the generic collections from System.Collections.Generic.

