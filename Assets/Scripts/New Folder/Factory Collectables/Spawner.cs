using UnityEngine;
using System.Collections;

public class CollectableSpawner : MonoBehaviour
{
    public CollectableFactory factory;
    public Transform player;
    public float spawnRadius = 10f;
    public float spawnInterval = 3f;
    public int maxCollectables = 5;

    private int currentCollectables = 0;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentCollectables < maxCollectables)
            {
                SpawnRandomCollectable();
            }
        }
    }

    public void SpawnRandomCollectable()
    {
        CollectableType randomType = (CollectableType)Random.Range(0, 2);

        Vector3 randomPos = player.position + new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            0, // same Y-level as player
            Random.Range(-spawnRadius, spawnRadius)
        );

        factory.CreateCollectable(randomType, randomPos);
        currentCollectables++;
    }

    public void OnCollectableDestroyed()
    {
        currentCollectables--;
    }
}