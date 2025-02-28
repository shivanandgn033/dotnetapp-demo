using System;
namespace delegatedemo.delegateclass;

public class lambdaexpression
{

   public static void lambdaexpressions()
   {
      Func<int, int> square = x => x * x;
      int result = square(5); // result will be 25
      Console.WriteLine(result);
     
      Func<int, int, int> add = (a, b) => a + b;
      int sum = add(10, 20); // sum will be 30
      Console.WriteLine(sum);



      Func<int, bool> isEven = num =>
        {
            return num % 2 == 0;
        };
      bool evenResult = isEven(6); // evenResult will be true
      Console.WriteLine(evenResult);

      
      List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
      List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
      // evenNumbers will contain { 2, 4, 6 }
      foreach(int number in evenNumbers){
       Console.WriteLine(number);
      }


     Func<double, double, double> multiply = (double x, double y) => x * y;
     double product = multiply(2.5, 4.0);
     Console.WriteLine(product);

     Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
     greet("Alice"); // Output: Hello, Alice!

   }

}
