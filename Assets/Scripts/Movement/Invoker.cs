using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
        }
    }
}