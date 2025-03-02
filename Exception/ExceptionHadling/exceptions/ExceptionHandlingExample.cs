namespace ExceptionHadling;

public class ExceptionHandlingExample
{
  public static void exceptioncall()
  {
        try
        {
            // Code that might throw an exception
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input); // Potential FormatException

            int result = 10 / number; // Potential DivideByZeroException
            Console.WriteLine("Result: " + result);

            int[] myArray = { 1, 2, 3 };
            Console.WriteLine(myArray[3]); //Potential IndexOutOfRangeException
        }
        catch (FormatException ex)
        {
            // Handle FormatException (e.g., if the user enters non-numeric input)
            Console.WriteLine("Error: Invalid input format. Please enter a valid number.");
            Console.WriteLine("Details: " + ex.Message); //Optional, but useful for debugging
        }
        catch (DivideByZeroException ex)
        {
            // Handle DivideByZeroException (e.g., if the user enters 0)
            Console.WriteLine("Error: Cannot divide by zero.");
            Console.WriteLine("Details: " + ex.Message);

        }
        catch (IndexOutOfRangeException ex)
        {
            //Handles accessing array indexes that don't exist
            Console.WriteLine("Error: Array index was out of range.");
            Console.WriteLine("Details: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions (general catch block)
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine("Details: " + ex.Message); //Good for debugging, but consider more user-friendly messages for production
        }
        finally
        {
            // Code that always executes, regardless of whether an exception occurred
            Console.WriteLine("Execution complete.");
            //Typically used for cleanup (closing files, releasing resources)
        }
        Console.WriteLine("Program continues after exception handling."); //Program will continue if an exception is caught.
  }
}
