using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchLens : MonoBehaviour{
	public Lens.LensList CurrentLens = Lens.LensList.NONE;
	Lens[] LensItems;
	public TextMeshProUGUI CurrentLensText;
	private void Start() {
		LensItems = (Lens[])FindObjectsOfType(typeof(Lens));
	}

	public void OnSwapLens() {
		Lens.LensList PreviousLens = CurrentLens;
		switch (CurrentLens) { 
			case Lens.LensList.NONE: {
				CurrentLens = Lens.LensList.REVEAL;
				CurrentLensText.text = "Reveal Lens";
				break;
			}
			case Lens.LensList.REVEAL: {
				CurrentLens = Lens.LensList.REVERSE;
				CurrentLensText.text = "Reverse Lens";
				break;
			}
			case Lens.LensList.REVERSE: {
				CurrentLens = Lens.LensList.REALITY;
				CurrentLensText.text = "Reality Lens";
				break;
			}
			case Lens.LensList.REALITY: {
				CurrentLens = Lens.LensList.NONE;
				CurrentLensText.text = "No Lens";
				break;
			}
		}

		
		for (int i = 0; i < LensItems.Length; i++) { 
			if(CurrentLens == LensItems[i].VisibleLens) {
				LensItems[i].ActivateLens();
			}else if ((int)PreviousLens == (int)LensItems[i].VisibleLens) {
				LensItems[i].DeactivateLens();
			}
		}
	}
}
