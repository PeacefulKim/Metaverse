using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bestScoreTxt;
    public TextMeshProUGUI restartTxt;
    void Start()
    {
        if (restartTxt == null) Debug.Log("Restart text is null");
        if (scoreTxt == null)
        {
            Debug.Log("Score text is null");
            return;
        }
        restartTxt.gameObject.SetActive(false);
    }
    public void SetRestart()
    {
        restartTxt.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
    public void UpdateBestScore(int score)
    {
        bestScoreTxt.text = "Best Score: " + score.ToString();
    }
}
