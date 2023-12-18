using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPiece : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Open this mf");
        return true;
    }
}
