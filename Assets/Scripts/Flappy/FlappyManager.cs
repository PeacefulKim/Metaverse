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
    private int currentScore = 0;

    private void Awake()
    {
        flappyManager = this;
        scoreManager = FindObjectOfType<ScoreUIManager>();
    }
    private void Start()
    {
        scoreManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        scoreManager.SetRestart();
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
}
