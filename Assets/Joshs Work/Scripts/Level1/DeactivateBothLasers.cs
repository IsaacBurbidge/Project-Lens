using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBothLasers : MonoBehaviour {
	[SerializeField]
	private GameObject firstLaserSet;
	[SerializeField]
	private GameObject secondLaserSet;
	[SerializeField]
	private GameObject doorToOpen;
	[SerializeField]
	private GameObject laserRoomExitMessage;

	public void areAllLasersOff() {
		// Only plays Bridge Fix animation if both bridge pieces are tagged as reversable
		if (firstLaserSet.activeInHierarchy == false && secondLaserSet.activeInHierarchy == false) {
			doorToOpen.GetComponent<Animator>().SetBool("isDoorOpen", true);
		}	
		// Change Exit Laser Room UI Text based on how many lasers are on
		if (firstLaserSet.activeInHierarchy == true && secondLaserSet.activeInHierarchy == false || firstLaserSet.activeInHierarchy == false && secondLaserSet.activeInHierarchy == true) {
			laserRoomExitMessage.GetComponent<UIPromptTextToShow>().uiPromptText = "Have you switched off the rest of the lasers yet?";
		} 
		else if (firstLaserSet.activeInHierarchy == false && secondLaserSet.activeInHierarchy == false) {
			laserRoomExitMessage.GetComponent<UIPromptTextToShow>().uiPromptText = "You may pass!";
		}
	}
}