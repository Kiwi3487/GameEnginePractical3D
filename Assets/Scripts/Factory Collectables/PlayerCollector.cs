using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public int score = 0;
    public int winScore = 100;

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);

        if (score >= winScore)
        {
            GameSceneManager.Instance.LoadScene("WinScene");
        }
    }
}