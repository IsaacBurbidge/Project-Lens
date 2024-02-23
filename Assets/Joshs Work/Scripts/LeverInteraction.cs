using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour {
    //[SerializeField]
    //private Lever leverScript;
	[SerializeField]
	private Animator firstDoorAnimator;
	[SerializeField]
	private Animator secondDoorAnimator;
	public bool canPushLever = false;
    public bool hasPushedLever = false;

    // Start is called before the first frame update
    void Start() {

    }

    void FixedUpdate() {
        // If Lever has been fixed, enable interaction with the Lever
        //if (leverScript.IsFixed == true) {
        //    canPushLever = true;
        //}
    }

    public void PlayFirstDoorLeverAnim() {
        // If the Lever is interactable (has been fixed), play the lever animation
        if (canPushLever == true) {
			firstDoorAnimator.SetBool("IsOpen", true);
		}
    }

	public void PlaySecondDoorLeverAnim() {
		// If the Lever is interactable (has been fixed), play the lever animation
		if (canPushLever == true) {
			secondDoorAnimator.SetBool("IsOpen", true);
		}
	}

	private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponentInChildren<CapsuleCollider>().CompareTag("Lever")) {
    
			//leverScript.IsOpen = true;
			firstDoorAnimator.SetBool("IsOpen", true);
			Debug.Log("Play Lever Animation");
            PlayFirstDoorLeverAnim();
            PlaySecondDoorLeverAnim();
		}
        //private void OnCollisionEnter(Collision other){
        //    Debug.Log("Hand Collision");
        //    // Player hands interaction with the Lever
        //    if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand") || other.gameObject.name == "LeverBase") {
        //        PlayLeverAnim();
        //        Debug.Log("Hand Collision");

        //    }

        //}
    }
}