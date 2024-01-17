using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour {
    [SerializeField] 
    private Lever leverScript;
    public bool canPushLever = false;
    public bool hasPushedLever = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    void FixedUpdate() {
        // If Lever has been fixed, enable interaction with the Lever
        if (leverScript.IsFixed == true) {
            canPushLever = true;
        }
    }

    private void PlayLeverAnim() {
        // If the Lever is interactable (has been fixed), play the lever animation
        if(canPushLever == true) {
            Debug.Log("Play Lever Push Animation");
        }
    }

    private void OnCollisionEnter(Collision other){
        Debug.Log("Hand Collision");
        // Player hands interaction with the Lever
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand") || other.gameObject.name == "LeverBase") {
            PlayLeverAnim();
            Debug.Log("Hand Collision");

        }

    }
}
