using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [Header("Prompts")]
    [SerializeField] public string lockedPrompt;
    [SerializeField] public string unlockedPrompt;

    [Header("Events")]
    [SerializeField] private bool triggersEvent;
    [SerializeField] Eventy eventTrigger;
    private string prompt;
    public bool hasLeverPiece = false;

    public string InteractionPrompt => prompt;

    private void Start()
    {
        prompt = lockedPrompt;
    }
    public void UnlockDoor()
    {
        hasLeverPiece = true;
        prompt = unlockedPrompt;
    }

    public bool Interact(Interactor interactor)
    {
        if (hasLeverPiece)
        {
            Debug.Log("Open door");
            if(triggersEvent)
            {
                eventTrigger.triggerTheEvent();
            }
            return true;
        }

        Debug.Log("you need the switch piece");
        return false;
    }
}
