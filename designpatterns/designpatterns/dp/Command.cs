
using System;
using System.Collections.Generic;


namespace designpatterns.dp;

// 1. Command Interface
public interface ICommand
{
    void Execute();
    void Undo(); // Optional Undo Operation
}

// 2. Receiver: Text Editor
public class TextEditor
{
    public string _text = "";

    public void InsertText(string text)
    {
        _text += text;
        Console.WriteLine($"Text Editor: Inserted '{text}'. Current text: '{_text}'");
    }

    public void DeleteLastCharacter()
    {
        if (_text.Length > 0)
        {
            _text = _text.Substring(0, _text.Length - 1);
            Console.WriteLine($"Text Editor: Deleted last character. Current text: '{_text}'");
        }
        else
        {
            Console.WriteLine("Text Editor: Nothing to delete.");
        }
    }

    public string GetText()
    {
        return _text;
    }
}

// 3. Concrete Commands
public class InsertTextCommand : ICommand
{
    private TextEditor _editor;
    private string _textToInsert;
    private string _previousText; // For Undo

    public InsertTextCommand(TextEditor editor, string textToInsert)
    {
        _editor = editor;
        _textToInsert = textToInsert;
    }

    public void Execute()
    {
        _previousText = _editor.GetText(); // Save state for undo
        _editor.InsertText(_textToInsert);
    }

    public void Undo()
    {
        _editor.SetText(_previousText); // Restore previous state
        Console.WriteLine($"Undo: InsertText. Text restored to: '{_editor.GetText()}'");
    }
}

public class DeleteTextCommand : ICommand
{
    private TextEditor _editor;
    private string _deletedCharacter; // For Undo
    private string _previousText;     // For Undo

    public DeleteTextCommand(TextEditor editor)
    {
        _editor = editor;
    }

    public void Execute()
    {
        _previousText = _editor.GetText(); // Save state for undo
        _deletedCharacter = _editor.GetLastCharacter(); // Save deleted char for undo
        _editor.DeleteLastCharacter();
    }

    public void Undo()
    {
        if (_deletedCharacter != null) // Only undo if something was deleted
        {
            _editor.InsertText(_deletedCharacter); // Re-insert deleted character
            _editor.SetText(_previousText); // Restore state *before* deletion (important if multiple deletes happened)
            Console.WriteLine($"Undo: DeleteText. Text restored to: '{_editor.GetText()}'");
        }
        else
        {
            Console.WriteLine("Undo: DeleteText - Nothing to undo (nothing was deleted).");
        }
    }
}


// Extension method to help with DeleteTextCommand's Undo (not core Command pattern, but helpful for example)
public static class TextEditorExtensions
{
    public static string GetLastCharacter(this TextEditor editor)
    {
        string currentText = editor.GetText();
        if (currentText.Length > 0)
        {
            return currentText.Substring(currentText.Length - 1);
        }
        return null; // Or String.Empty if you prefer
    }

    public static void SetText(this TextEditor editor, string text)
    {
        editor._text = text; // Direct access for simplicity in example, consider encapsulation for real scenarios
    }
}


// 4. Invoker: EditorInvoker (or could be part of Client in simple example)
public class EditorInvoker
{
    private List<ICommand> _commandHistory = new List<ICommand>();
    private TextEditor _editor;

    public EditorInvoker(TextEditor editor)
    {
        _editor = editor;
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Add(command); // Add to history for undo
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand lastCommand = _commandHistory[_commandHistory.Count - 1];
            lastCommand.Undo();
            _commandHistory.RemoveAt(_commandHistory.Count - 1); // Remove from history after undo
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}