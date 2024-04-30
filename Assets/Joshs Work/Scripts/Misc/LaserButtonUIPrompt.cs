using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaserButtonUIPrompt : Lens {
	[SerializeField]
	private SwitchLens switchLensScript;
	[SerializeField]
	private TextMeshProUGUI laserUIPromptText;

	void Start() {
        VisibleLens = LensList.REVEAL;
    }
	// Display a UI Prompt to turn off the lasers if the Player has the Reveal lens currently activated
	// and they are within the proximity of the UI text trigger
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Player") { 			
            if(switchLensScript.CurrentLens == LensList.REVEAL) {
				laserUIPromptText.enabled = true;
			}
			else {
				laserUIPromptText.enabled = false;
			}
        }
	}
	private void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			if (switchLensScript.CurrentLens == LensList.REVEAL) {
				laserUIPromptText.enabled = true;
			}
			else {
				laserUIPromptText.enabled = false;
			}
		}
	}
	private void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			if (switchLensScript.CurrentLens != LensList.REVEAL) {
				laserUIPromptText.enabled = false;
			}
		}
	}
}