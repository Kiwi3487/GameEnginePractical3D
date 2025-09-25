using Assets;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private LayerMask placementMask;
    [SerializeField] private Receiver receiver;
    [SerializeField] private Invoker invoker;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySpawnCube();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            invoker.Undo();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            invoker.Redo();
        }
    }

    private void TrySpawnCube()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, placementMask))
        {
            ICommand command = new PlaceCubeCommand(receiver, hit.point);
            invoker.ExecuteCommand(command);
        }
    }
}