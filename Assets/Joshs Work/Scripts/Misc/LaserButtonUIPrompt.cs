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