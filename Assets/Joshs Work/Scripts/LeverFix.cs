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


	private void Start() {
		
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.name);
		if (HasLeverHandle == false && other.gameObject.CompareTag("Lever")) {
			HasLeverHandle = true;
			Destroy(LeverInHandObject);
			// Display Updated UI Prompt
			LeverHandleUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "Give it a try now!";
			Animator.SetBool("HasLeverHandle", true);
		}
	}

	//public bool IsFixed = false;
	//public bool IsOpen = false;
	//[SerializeField]
	//private GameObject TopOfLever;

	//[SerializeField]
	//private Animator Animator;

	//private void Start() {
	//	Animator = GetComponent<Animator>();
	//}

	//private void OnTriggerEnter(Collider other) {
	//	if (!IsFixed && other.tag == "Fix") {
	//		TopOfLever.SetActive(true);
	//		Destroy(other.gameObject);
	//		Animator.SetBool("IsFixed", true);
	//	}
	//}
}
