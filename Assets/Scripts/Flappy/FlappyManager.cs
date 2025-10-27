using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager : MonoBehaviour
{
    static FlappyManager flappyManager;
    public static FlappyManager Instance { get { return flappyManager; } }

    static ScoreUIManager scoreManager;
    public static ScoreUIManager ScoreManager { get { return scoreManager; } }
    public int BestScore { get => bestScore; }
    private int currentScore = 0;
    int bestScore = 0;

    private const string BestScoreKey = "BestScore";

    private void Awake()
    {
        flappyManager = this;
        scoreManager = FindObjectOfType<ScoreUIManager>();
    }
    private void Start()
    {
        scoreManager.UpdateScore(0);
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }
    public void GameOver()
    {
        scoreManager.SetRestart();
        UpdateScore();
        scoreManager.UpdateBestScore(bestScore);
        Debug.Log(bestScore);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void AddScore(int score)
    {
        currentScore += score;
        scoreManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
    public void UpdateScore()
    {
        if(bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
    }
}
