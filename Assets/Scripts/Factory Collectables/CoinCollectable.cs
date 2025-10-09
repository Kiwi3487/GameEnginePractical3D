using UnityEngine;

public class CoinCollectable : Collectable
{
    private void Start()
    {
        pointsValue = 10;
    }

    public override void OnCollect(PlayerCollector player)
    {
        player.AddPoints(pointsValue);
    }
}