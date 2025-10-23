using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloNpc : MonoBehaviour, Iinteract
{
    private string npcName = "작은 태양";
    private string dialogue = "안녕하세요! 편하게 쉬다 가세요!";

    public void Interact()
    {
        Debug.Log($"{npcName}: {dialogue}");
    }
}
