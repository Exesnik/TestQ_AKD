using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageButton : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Animator animator;
    private bool isOpen = false;

  
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    public void Interact()
    {
        if (isOpen)    
            CloseDoor();
        else
            OpenDoor(); 
    }

    private void OpenDoor()
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }

    private void CloseDoor()
    {
        animator.SetTrigger("Close"); 
        isOpen = false; 
    }

    
}
