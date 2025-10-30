using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject fuelPrefab;
    
    public float spawnInterval = 1.5f;
    public float spawnRangeX = 4f;
    public float moveSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        bool spawnFuel = Random.Range(0, 10) == 1;
        GameObject prefabToSpawn = spawnFuel ? fuelPrefab : carPrefab;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.2f, transform.position.z);
        GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        Mover mover = obj.AddComponent<Mover>();
        mover.speed = moveSpeed;
    }
}