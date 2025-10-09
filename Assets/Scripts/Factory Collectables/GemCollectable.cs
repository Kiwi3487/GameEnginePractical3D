using UnityEngine;

public class GemCollectable : Collectable
{
    private void Start()
    {
        pointsValue = 25;
    }

    public override void OnCollect(PlayerCollector player)
    {
        player.AddPoints(pointsValue);
    }
}