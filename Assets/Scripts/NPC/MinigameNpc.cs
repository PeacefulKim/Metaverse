using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameNpc : MonoBehaviour, Iinteract
{
    public string npcName = "미니게임";
    public void Interact()
    {
        Debug.Log(npcName);
    }
}
