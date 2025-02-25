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
