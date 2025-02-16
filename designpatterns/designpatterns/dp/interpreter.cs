namespace designpatterns.dp;

using System;
using System.Collections.Generic;

// 1. Abstract Expression Interface
public interface IExpression
{
    bool Interpret(Context context);
}

// 2. Context Class
public class Context
{
    private Dictionary<string, bool> _variables = new Dictionary<string, bool>();

    public void SetVariable(string name, bool value)
    {
        _variables[name] = value;
    }

    public bool GetVariable(string name)
    {
        if (_variables.ContainsKey(name))
        {
            return _variables[name];
        }
        return false; // Default to false if variable not found
    }
}

// 3. Terminal Expressions
public class VariableExpression : IExpression
{
    private string _variableName;

    public VariableExpression(string variableName)
    {
        _variableName = variableName;
    }

    public bool Interpret(Context context)
    {
        return context.GetVariable(_variableName);
    }
}

public class LiteralExpression : IExpression
{
    private bool _value;

    public LiteralExpression(bool value)
    {
        _value = value;
    }

    public bool Interpret(Context context)
    {
        return _value;
    }
}

// 4. Nonterminal Expressions
public class AndExpression : IExpression
{
    private IExpression _expression1;
    private IExpression _expression2;

    public AndExpression(IExpression expression1, IExpression expression2)
    {
        _expression1 = expression1;
        _expression2 = expression2;
    }

    public bool Interpret(Context context)
    {
        return _expression1.Interpret(context) && _expression2.Interpret(context);
    }
}

public class OrExpression : IExpression
{
    private IExpression _expression1;
    private IExpression _expression2;

    public OrExpression(IExpression expression1, IExpression expression2)
    {
        _expression1 = expression1;
        _expression2 = expression2;
    }

    public bool Interpret(Context context)
    {
        return _expression1.Interpret(context) || _expression2.Interpret(context);
    }
}

public class NotExpression : IExpression
{
    private IExpression _expression;

    public NotExpression(IExpression expression)
    {
        _expression = expression;
    }

    public bool Interpret(Context context)
    {
        return !_expression.Interpret(context);
    }
}