using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloNpc : MonoBehaviour, Iinteract
{
    private string npcName = "���� �¾�";
    private string dialogue = "�ȳ��ϼ���! ���ϰ� ���� ������!";

    public void Interact()
    {
        Debug.Log($"{npcName}: {dialogue}");
    }
}
