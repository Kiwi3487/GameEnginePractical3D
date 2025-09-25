using Assets;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    private Receiver _receiver;
    private Vector3 position;
    private GameObject placedCube;

    public PlaceCubeCommand(Receiver receiver, Vector3 position)
    {
        _receiver = receiver;
        this.position = position;
    }

    public void Execute()
    {
        placedCube = _receiver.PlaceCube(position);
    }

    public void Undo()
    {
        if (placedCube != null)
        {
            _receiver.RemoveCube(placedCube);
        }
    }
}