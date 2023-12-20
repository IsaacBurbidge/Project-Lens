using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPiece : MonoBehaviour, IInteractable
{
    [SerializeField] private LockedDoor lockedDoor;
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        lockedDoor.UnlockDoor();
        GameObject.Destroy(gameObject);
        return true;
    }
}
