using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameNpc : MonoBehaviour, Iinteract
{
    public TextMeshProUGUI scoreTxt;
    private const string BestScoreKey = "BestScore";

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Flappy");
        }
    }
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        scoreTxt.text = $"Best Score: {bestScore}";
    }
}
