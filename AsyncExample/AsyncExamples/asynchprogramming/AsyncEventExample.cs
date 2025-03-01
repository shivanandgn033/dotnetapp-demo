using System;
using System.Threading.Tasks;
namespace AsyncExamples.asynchprogramming;
public class AsyncEventExample
{
        // Custom event arguments to carry the result of the task.
    public class TaskCompletedEventArgs : EventArgs
    {
        public string Result { get; }

        public TaskCompletedEventArgs(string result)
        {
            Result = result;
        }
    }

    // Event declaration.
    public event EventHandler<TaskCompletedEventArgs> TaskCompleted;

    // Asynchronous method that simulates a long-running operation.
    public async Task PerformTaskAsync(string taskId)
    {
        Console.WriteLine($"Task {taskId} started.");

        // Simulate a delay.
        await Task.Delay(2000);

        string result = $"Result of Task {taskId}";
        Console.WriteLine($"Task {taskId} completed with result: {result}");

        // Raise the event when the task is completed.
        OnTaskCompleted(new TaskCompletedEventArgs(result));
    }

    // Method to raise the event.
    protected virtual void OnTaskCompleted(TaskCompletedEventArgs e)
    {
        TaskCompleted?.Invoke(this, e);
    }
}
