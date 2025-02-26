using System;
namespace delegatedemo.delegateclass;

public class DelegateExample
{
      // 2. Methods that match the delegate signature
    public static int Add(int a, int b) { return a + b; }
    public static int Subtract(int a, int b) { return a - b; }
    public static int Multiply(int a, int b) { return a * b; }
    public static int Divide(int a, int b) { return a / b; }

     // 1. Delegate Declaration (Defining the signature)
    delegate int MathOperation(int x, int y); // Declares a delegate type

   public static void calldelegateExample(){

            // 3. Delegate Instantiation (Creating delegate instances)
        MathOperation addDelegate = new MathOperation(Add);
        MathOperation subtractDelegate = new MathOperation(Subtract);
        MathOperation multiplyDelegate = new MathOperation(Multiply);
        MathOperation divideDelegate = new MathOperation(Divide);

        // Or, more concisely (type inference):
        MathOperation addDelegate2 = Add;
        MathOperation subtractDelegate2 = Subtract;



        // 4. Delegate Invocation (Calling the methods through the delegates)
        int result1 = addDelegate(10, 5);
        int result2 = subtractDelegate(10, 5);
        int result3 = multiplyDelegate(10, 5);
        int result4 = divideDelegate(10, 5);

        Console.WriteLine($"Add: {result1}");
        Console.WriteLine($"Subtract: {result2}");
        Console.WriteLine($"Multiply: {result3}");
        Console.WriteLine($"Divide: {result4}");
   }


}
