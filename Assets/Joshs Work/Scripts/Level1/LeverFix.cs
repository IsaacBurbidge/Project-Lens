using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFix : MonoBehaviour {
	[SerializeField]
	private Animator Animator;
	[SerializeField]
	private GameObject LeverHandleUIPromptObject;
	[SerializeField]
	private GameObject LeverInHandObject;
	public bool HasLeverHandle = false;

	private void OnTriggerEnter(Collider other) {
		// Play the Animation of fixing the lever
		if (HasLeverHandle == false && other.gameObject.CompareTag("Lever")) {
			HasLeverHandle = true;
			Destroy(LeverInHandObject);
			// Display Updated UI Prompt
			LeverHandleUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "Give it a try now!";
			Animator.SetBool("HasLeverHandle", true);
		}
	}
}