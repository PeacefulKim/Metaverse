using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloNpc : MonoBehaviour, Iinteract
{
    private string dialogue = "�ȳ��ϼ���! ���ϰ� ���� ������!";

    public void Interact()
    {
        Debug.Log(dialogue);
    }
}
