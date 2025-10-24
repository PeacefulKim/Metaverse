using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    private Iinteract interactable;
    public GameObject bubblePrefab;
    public GameObject currentBubble;
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
        if (currentBubble != null) currentBubble.SetActive(false);
    }
    private void Update()
    {
        if (playerNearby && !isVisible) 
        {
            ShowBubble();
        }
        else if (!playerNearby && isVisible)
        {
            HideBubble();
        }
        if(playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact();
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
        if (bubblePrefab != null && currentBubble == null) 
        {
            currentBubble = Instantiate(bubblePrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
            Bubble bubble = currentBubble.GetComponent<Bubble>(); 
            if (bubble != null) bubble.target = transform;
            isVisible = true;
        }
    }
    void HideBubble()
    {
        if (currentBubble != null)
        {
            Destroy(currentBubble);
            currentBubble = null;
        }
        isVisible = false;
    }
}
public interface Iinteract
{
    void Interact();
}
