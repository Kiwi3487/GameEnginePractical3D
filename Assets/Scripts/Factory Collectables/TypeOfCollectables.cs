using UnityEngine;

public enum CollectableType
{
    Coin,
    Gem
}

public class CollectableFactory : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject coinPrefab;
    public GameObject gemPrefab;

    public GameObject CreateCollectable(CollectableType type, Vector3 position, CollectableSpawner spawner = null)
    {
        GameObject prefab = null;

        switch (type)
        {
            case CollectableType.Coin:
                prefab = coinPrefab;
                break;
            case CollectableType.Gem:
                prefab = gemPrefab;
                break;
        }

        if (prefab != null)
        {
            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            Collectable collectable = obj.GetComponent<Collectable>();
            if (collectable != null)
                collectable.Initialize(spawner);

            return obj;
        }

        Debug.LogWarning("Unknown collectable type!");
        return null;
    }
}