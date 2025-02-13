namespace designpatterns.dp;
using System;

// 1. Handler Interface (or Abstract Class)
public abstract class HelpHandler
{
    private HelpHandler _nextHandler;

    public HelpHandler SetNext(HelpHandler handler)
    {
        this._nextHandler = handler;
        return handler; // For fluent chaining
    }

    public virtual void HandleHelpRequest(HelpRequest request)
    {
        if (_nextHandler != null)
        {
            _nextHandler.HandleHelpRequest(request); // Pass to the next in chain
        }
        else
        {
            Console.WriteLine($"No handler in chain could process help request for context: {request.HelpContext}.");
        }
    }

    // Abstract method to be implemented by concrete handlers
    public abstract bool CanHandleRequest(HelpRequest request);
}

// 2. Concrete Handlers
public class ButtonHelpHandler : HelpHandler
{
    private readonly string _buttonHelpContext = "Button";

    public override bool CanHandleRequest(HelpRequest request)
    {
        return request.HelpContext == _buttonHelpContext;
    }

    public override void HandleHelpRequest(HelpRequest request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"ButtonHelpHandler is providing help for: {request.HelpContext}");
            // Provide specific help for buttons here
        }
        else
        {
            base.HandleHelpRequest(request); // Pass to the next handler in chain
        }
    }
}

public class FormHelpHandler : HelpHandler
{
    private readonly string _formHelpContext = "Form";

    public override bool CanHandleRequest(HelpRequest request)
    {
        return request.HelpContext == _formHelpContext;
    }

    public override void HandleHelpRequest(HelpRequest request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"FormHelpHandler is providing help for: {request.HelpContext}");
            // Provide specific help for forms here
        }
        else
        {
            base.HandleHelpRequest(request); // Pass to the next handler in chain
        }
    }
}

public class ApplicationHelpHandler : HelpHandler
{
    private readonly string _applicationHelpContext = "Application";

    public override bool CanHandleRequest(HelpRequest request)
    {
        return request.HelpContext == _applicationHelpContext || request.HelpContext == "General"; // Handles general requests too
    }

    public override void HandleHelpRequest(HelpRequest request)
    {
        if (CanHandleRequest(request))
        {
            Console.WriteLine($"ApplicationHelpHandler is providing general application help for: {request.HelpContext}");
            // Provide general application help here
        }
        else
        {
            base.HandleHelpRequest(request); // Pass to the next handler in chain (which will be null in this example, ending the chain)
        }
    }
}

// 3. Request Class
public class HelpRequest
{
    public string HelpContext { get; }

    public HelpRequest(string context)
    {
        HelpContext = context;
    }
}