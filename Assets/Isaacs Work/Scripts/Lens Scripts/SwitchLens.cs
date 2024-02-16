using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLens : MonoBehaviour {
	[SerializeField]
	private Image lensTintImage;
	public Lens.LensList CurrentLens = Lens.LensList.NONE;
	Lens[] LensItems;

	private void Start() {
		LensItems = (Lens[])FindObjectsOfType(typeof(Lens));
	}
	private void RedTint() {
		Color imageColour;
		imageColour.r = 1.0f;
		imageColour.g = 0.0f;
		imageColour.b = 0.0f;
		imageColour.a = 0.35f;
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
		
	}
	private void GreenTint() {
		Color imageColour;
		imageColour.r = 0.0f;
		imageColour.g = 1.0f;
		imageColour.b = 0.0f;
		imageColour.a = 0.35f;
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
	}
	private void BlueTint() {
		Color imageColour;
		imageColour.r = 0.0f;
		imageColour.g = 0.0f;
		imageColour.b = 1.0f;
		imageColour.a = 0.35f;	
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
	}
	public void OnSwapLens() {
		Lens.LensList PreviousLens = CurrentLens;
		switch (CurrentLens) {
			case Lens.LensList.NONE: {
				CurrentLens = Lens.LensList.REVEAL;
				RedTint();
				break;
			}
			case Lens.LensList.REVEAL: {
				CurrentLens = Lens.LensList.REVERSE;
				GreenTint();
				break;
			}
			case Lens.LensList.REVERSE: {
				CurrentLens = Lens.LensList.REALITY;
				BlueTint();
				break;
			}
			case Lens.LensList.REALITY: {
				CurrentLens = Lens.LensList.NONE;
				lensTintImage.enabled = false;
				break;
			}
		}

		for (int i = 0; i < LensItems.Length; i++) {
			if (CurrentLens == LensItems[i].VisibleLens) {
				LensItems[i].ActivateLens();
			}
			else if ((int)PreviousLens == (int)LensItems[i].VisibleLens) {
				LensItems[i].DeactivateLens();
			}
		}
	}

	public void LensWheelSwap(Lens.LensList NextLens) {
		Lens.LensList PreviousLens = CurrentLens;
		CurrentLens = NextLens;

		switch (CurrentLens) {
			case Lens.LensList.NONE: {
				lensTintImage.enabled = false;
				break;
			}
			case Lens.LensList.REVEAL: {
				RedTint();
				break;
			}
			case Lens.LensList.REVERSE: {
				GreenTint();
				break;
			}
			case Lens.LensList.REALITY: {
				BlueTint();
				break;
			}
		}
		for (int i = 0; i < LensItems.Length; i++) {
			if (CurrentLens == LensItems[i].VisibleLens) {
				LensItems[i].ActivateLens();
			}
			else if ((int)PreviousLens == (int)LensItems[i].VisibleLens) {
				LensItems[i].DeactivateLens();
			}
		}
	}
}