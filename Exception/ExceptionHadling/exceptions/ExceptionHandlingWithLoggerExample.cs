using Microsoft.Extensions.Logging;
using System;
namespace ExceptionHadling;

public class ExceptionHandlingWithLoggerExample
{
    private readonly ILogger<ExceptionHandlingWithLoggerExample> _logger;

    public ExceptionHandlingWithLoggerExample(ILogger<ExceptionHandlingWithLoggerExample> logger)
    {
        _logger = logger;
    }

    public void PerformOperation(string input)
    {
        try
        {
            _logger.LogInformation("Starting PerformOperation with input: {Input}", input);

            int number = int.Parse(input);
            int result = 10 / number;

            _logger.LogInformation("Operation successful. Result: {Result}", result);
        }
        catch (FormatException ex)
        {
            _logger.LogError(ex, "Invalid input format. Input: {Input}", input);
            // Optionally re-throw or handle the exception further.
            throw; //re-throwing for demonstration.
        }
        catch (DivideByZeroException ex)
        {
            _logger.LogError(ex, "Division by zero attempted. Input: {Input}", input);
            // Optionally re-throw or handle the exception further.
            throw;//re-throwing for demonstration.
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred. Input: {Input}", input);
            // Optionally re-throw or handle the exception further.
            throw; //re-throwing for demonstration.
        }
        finally
        {
            _logger.LogInformation("PerformOperation completed.");
        }
}
}
