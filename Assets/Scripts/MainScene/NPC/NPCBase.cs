using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    private Iinteract interactable;
    public GameObject speechBubble;
    private bool playerNearby = false;
    private bool isVisible = false;
    private void Awake()
    {
        interactable = GetComponent<Iinteract>();
        if(interactable == null)
        {
            Debug.LogError("Iinteract is null");
        }
    }
    private void Start()
    {
        if (speechBubble != null) speechBubble.SetActive(false);
    }
    private void Update()
    {
        if (playerNearby && !isVisible) 
        {
            ShowBubble();
            if(Input.GetKeyDown(KeyCode.E)) interactable.Interact();
            return;
        }
        else if (!playerNearby && isVisible)
        {
            HideBubble();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearby = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearby = false;
    }
    void ShowBubble()
    {
        if (speechBubble != null)
        {
            speechBubble.SetActive(true);
            isVisible = true;
        }
    }
    void HideBubble()
    {
        if (speechBubble != null)
        {
            speechBubble.SetActive(false);
            isVisible = false;
        }
    }
}
public interface Iinteract
{
    void Interact();
}
