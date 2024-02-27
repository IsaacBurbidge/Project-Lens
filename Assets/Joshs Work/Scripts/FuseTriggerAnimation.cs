using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseTriggerAnimation : MonoBehaviour {
	[SerializeField]
	private Animator firstDoorAnimator;
	[SerializeField]
	private Animator secondDoorAnimator;
	public static bool isFirstDoorOpen = false;
	[SerializeField]
	private Material fuseMaterial;
	[SerializeField]
	private GameObject leftFuseUIPromptObject;
	[SerializeField]
	private GameObject middleFuseUIPromptObject;
	private void Start () {
		isFirstDoorOpen = false;

	}
	private void OnTriggerStay(Collider other) {
		if (isFirstDoorOpen == false && other.gameObject.name == "LeftFuse_Trigger" || other.gameObject.name == "MiddleFuse_Trigger") {
			other.gameObject.GetComponentInParent<MeshRenderer>().material = fuseMaterial;
			firstDoorAnimator.SetBool("openDoor", true);
			isFirstDoorOpen = true;

			if(other.gameObject.name == "LeftFuse_Trigger") {
				other.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
				// Display Updated UI Prompt
				leftFuseUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "This fuse has already been activated...";
			}else if(other.gameObject.name == "MiddleFuse_Trigger") {
				other.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
				// Display Updated UI Prompt
				middleFuseUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "This fuse has already been activated...";
			}
			
			Destroy(gameObject);
		}
		else if (isFirstDoorOpen == true && other.gameObject.name == "LeftFuse_Trigger" || other.gameObject.name == "MiddleFuse_Trigger") {
			other.gameObject.GetComponentInParent<MeshRenderer>().material = fuseMaterial;
			secondDoorAnimator.SetBool("openDoor", true);

			if (other.gameObject.name == "LeftFuse_Trigger") {
				other.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
				// Display Updated UI Prompt
				leftFuseUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "This fuse has already been activated...";
			}
			else if (other.gameObject.name == "MiddleFuse_Trigger") {
				other.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
				// Display Updated UI Prompt
				middleFuseUIPromptObject.GetComponent<UIPromptTextToShow>().uiPromptText = "This fuse has already been activated...";
			}

			Destroy(gameObject);
		}
	}
	private void Update() {
		Debug.Log(isFirstDoorOpen);
	}
}