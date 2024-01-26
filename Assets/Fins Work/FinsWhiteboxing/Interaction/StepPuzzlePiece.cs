using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StepPuzzlePiece : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent TheEvent;
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;
    public bool Interact(Interactor interactor)
    {
        TheEvent.Invoke();
        GameObject.Destroy(gameObject);
        return true;
    }
}
