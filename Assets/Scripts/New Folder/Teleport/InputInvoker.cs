using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Player player;
    private Stack<Command> commandHistory = new();

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Command command = null;

        if (Input.GetKeyDown(KeyCode.W))
            command = new MoveCommand(player, Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.S))
            command = new MoveCommand(player, Vector3.back);
        else if (Input.GetKeyDown(KeyCode.A))
            command = new MoveCommand(player, Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            command = new MoveCommand(player, Vector3.right);

        if (command != null)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        if (Input.GetKeyDown(KeyCode.Z) && commandHistory.Count > 0)
        {
            Command lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}