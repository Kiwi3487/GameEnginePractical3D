using UnityEngine;
using System.Collections.Generic;

public class Receiver : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private List<GameObject> spawnedCubes = new List<GameObject>();

    public GameObject PlaceCube(Vector3 position)
    {
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
        spawnedCubes.Add(cube);
        return cube;
    }

    public void RemoveCube(GameObject cube)
    {
        if (cube != null)
        {
            spawnedCubes.Remove(cube);
            Destroy(cube);
        }
    }
}