using UnityEngine;
using System.IO;

public class PlayerCollector : MonoBehaviour
{
    public int score = 0;
    public int winScore = 100;

    void Update()
    {
        // Press X to save score
        if (Input.GetKeyDown(KeyCode.X))
        {
            SaveScoreToFile();
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);

        if (score >= winScore)
        {
            GameSceneManager.Instance.LoadScene("WinScene");
        }
    }

    private void SaveScoreToFile()
    {
        string folderPath = Path.Combine(Application.streamingAssetsPath);
        string filePath = Path.Combine(folderPath, "score.txt");
        
        File.WriteAllText(filePath, "Score: " + score);

    }
}
