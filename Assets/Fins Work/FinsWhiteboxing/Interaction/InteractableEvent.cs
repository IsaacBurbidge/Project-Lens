using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEvent : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] UnityEvent theEvent;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        theEvent.Invoke();
        return true;
    }
}
