using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepPuzzlePlacer : MonoBehaviour, IInteractable
{
    public UnityEvent triggerEvent;
    [SerializeField] private string prompt;
    public bool hasPiece = false;
    public Material pieceMaterial;
    MeshRenderer pieceRenderer;
    public string InteractionPrompt => prompt;

    private void Start()
    {
        pieceRenderer = GetComponent<MeshRenderer>();
    }

    public bool Interact(Interactor interactor)
    {
        if (hasPiece)
        {
            return false;
        }
        pieceRenderer.material = pieceMaterial;

        triggerEvent.Invoke();
        return true;
    }
}
