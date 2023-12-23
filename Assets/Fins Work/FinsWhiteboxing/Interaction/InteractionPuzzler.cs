using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPuzzler : MonoBehaviour, IInteractable
{
    private string prompt;
    public UnityEvent theEvent;

    [SerializeField] InteractionToggle[] interactToggles;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        foreach(InteractionToggle intToggle in interactToggles)
        {
            intToggle.CheckMaterial();
            if(intToggle.CheckMaterial() == false) 
            {
                Debug.Log("Unsucsessful");
                break;
            }
            theEvent.Invoke();
        }
        return false;
    }

  
}
