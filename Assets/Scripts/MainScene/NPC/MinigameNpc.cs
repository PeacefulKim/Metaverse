using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameNpc : MonoBehaviour, Iinteract
{
    public string npcName = "미니게임";
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Flappy");
        }
    }
}
