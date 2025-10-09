using UnityEngine;

public class MoveCommands : ICommand
{
    private PlayerController player;
    private Vector3 from;
    private Vector3 to;

    public MoveCommands(PlayerController player, Vector3 from, Vector3 to)
    {
        this.player = player;
        this.from = from;
        this.to = to;
    }

    public void Execute() { }

    public void Undo()
    {
        if (!player.isUndoing)
            player.StartCoroutine(player.SmoothMoveTo(from, 0.1f));
    }
}