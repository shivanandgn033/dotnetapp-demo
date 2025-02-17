namespace designpatterns.dp;

using System.Collections.Generic;

// Component Interface
public interface IComponent
{
    string Name { get; }
    void Display();
}

// Leaf: File
public class FileComponent : IComponent
{
    public string Name { get; }

    public FileComponent(string name)
    {
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {Name}");
    }
}

// Composite: Directory
public class DirectoryComponent : IComponent
{
    public string Name { get; }
    private List<IComponent> _children = new List<IComponent>();

    public DirectoryComponent(string name)
    {
        Name = name;
    }

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void Display()
    {
        Console.WriteLine($"Directory: {Name}");
        foreach (var component in _children)
        {
            component.Display(); // Recursively display children
        }
    }
}

