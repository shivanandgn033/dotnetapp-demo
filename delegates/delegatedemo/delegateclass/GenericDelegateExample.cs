using System;
namespace delegatedemo.delegateclass;

public class GenericDelegateExample
{
         // Generic method that uses Func<T, TResult>
    public static TResult Transform<T, TResult>(T input, Func<T, TResult> transformer)
    {
        Console.WriteLine($"Transforming input of type {typeof(T)} to type {typeof(TResult)}");
        return transformer(input);
    }

    // Generic method that uses Action<T>
    public static void Process<T>(T item, Action<T> processor)
    {
        Console.WriteLine($"Processing item of type {typeof(T)}");
        processor(item);
    }

    // Generic method that uses Predicate<T>
    public static bool IsValid<T>(T item, Predicate<T> validator)
    {
        Console.WriteLine($"Validating item of type {typeof(T)}");
        return validator(item);
    }

}
