using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public int pointsValue;
    private CollectableSpawner spawner;

    public abstract void OnCollect(PlayerCollector player);

    public void Initialize(CollectableSpawner spawnerRef)
    {
        spawner = spawnerRef;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCollector player = other.GetComponent<PlayerCollector>();
        if (player != null)
        {
            OnCollect(player);
            spawner?.OnCollectableDestroyed();
            Destroy(gameObject);
        }
    }
}