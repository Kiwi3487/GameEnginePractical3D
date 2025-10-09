using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerCollector player;
    public TextMeshProUGUI scoreText;
    public CollectableFactory factory;
    public CollectableSpawner spawner;

    void Start()
    {
        spawner.factory = factory;
        spawner.player = player.transform;
    }

    void Update()
    {
        scoreText.text = "Score: " + player.score;
    }
}