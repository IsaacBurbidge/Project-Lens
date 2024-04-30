using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverTriggerAnimation : MonoBehaviour {
	[SerializeField]
	private Animator Animator;
	public bool isDoorOpen = false;

	// Open the Door when the Lever has been pulled down into the Trigger
	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "OpenLeverDoorHandle_Trigger") {
			gameObject.GetComponent<XRGrabInteractable>().enabled = false;
			Animator.SetBool("isDoorOpen", true);
		}
	}
}