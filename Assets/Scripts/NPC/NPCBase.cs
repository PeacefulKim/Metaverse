using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    private Iinteract interactable;
    private bool playerNearby = false;
    private void Awake()
    {
        interactable = GetComponent<Iinteract>();
        if(interactable == null)
        {
            Debug.LogError("Iinteract is null");
        }
    }
    private void Update()
    {
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
}
