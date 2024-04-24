using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandAnimations : MonoBehaviour {
    public InputActionProperty pointAnimationAction;
    public InputActionProperty grabAnimationAction;
    [SerializeField]
    private Animator playerHandAnimator;

    // Update is called once per frame
    void Update() {
        // Point animation for VR Hands
        float triggerValue = pointAnimationAction.action.ReadValue<float>();
        if (pointAnimationAction.action.IsInProgress()) {
            playerHandAnimator.SetInteger("HandAnimation", 1);
        }
       
        // Grip/Fist animation for VR Hands
        float gripValue = grabAnimationAction.action.ReadValue<float>();
        if (grabAnimationAction.action.IsInProgress()) {
            playerHandAnimator.SetFloat("HandAnimation", 2);
        }
 
    }
}