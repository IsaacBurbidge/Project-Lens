using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour {
    [SerializeField]
    private Lever leverScript;
	[SerializeField]
	private Animator Animator;
	[SerializeField]
	private Animator doorAnimator;
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

    public void PlayLeverAnim() {
        // If the Lever is interactable (has been fixed), play the lever animation
        if (canPushLever == true) {
            Debug.Log("Play Lever Push Animation");
			Animator.SetBool("IsOpen", true);
			//doorAnimator.Play()
		}
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponentInChildren<CapsuleCollider>().CompareTag("Lever")) {
    
			leverScript.IsOpen = true;
			Animator.SetBool("IsOpen", true);
			Debug.Log("Play Lever Animation");
			PlayLeverAnim();
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