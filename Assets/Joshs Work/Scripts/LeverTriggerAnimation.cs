using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverTriggerAnimation : MonoBehaviour {
	[SerializeField]
	private Animator Animator;
	public bool isDoorOpen = false;

	// Start is called before the first frame update
	void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "OpenLevel03DoorHandle_Trigger") {
			gameObject.GetComponent<XRGrabInteractable>().enabled = false;
			Animator.SetBool("isDoorOpen", true);
		}
	}
}