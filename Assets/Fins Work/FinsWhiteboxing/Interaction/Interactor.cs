using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable iinteractable;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders,
            interactionMask);

        if(numFound >0)
        {
            iinteractable = colliders[0].GetComponent<IInteractable>();

            if(iinteractable != null)
            {
                if (!interactionPromptUI.IsDisplayed) interactionPromptUI.Setup(iinteractable.InteractionPrompt);

                if(Keyboard.current.qKey.wasPressedThisFrame) iinteractable.Interact(this);
            }
        }
        else
        {
            if (iinteractable != null) iinteractable = null;
            if (interactionPromptUI.IsDisplayed) interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
