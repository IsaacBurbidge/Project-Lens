using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLens : MonoBehaviour {
	[SerializeField]
	private Image lensTintImage;
	[SerializeField]
	private GameObject revealImage;
	[SerializeField]
	private GameObject realityImage;
	[SerializeField]
	private GameObject reverseImage;
	[SerializeField]
	private GameObject noLenseImage;
	[SerializeField]
	private GameObject revealWristImage;
	[SerializeField]
	private GameObject realityWristImage;
	[SerializeField]
	private GameObject reverseWristImage;
	[SerializeField]
	private GameObject noLenseWristImage;
	public Lens.LensList CurrentLens = Lens.LensList.NONE;
	Lens[] LensItems;
	[SerializeField]
	private ParticleAndOutlineManager particleAndOutlineManagerScript;
	[SerializeField]
	private LensWheelAnimationManager lensWheelAnimationManagerScript;

	private void Start() {
		LensItems = (Lens[])FindObjectsOfType(typeof(Lens));
	}
	private void RedTint() {
		Color imageColour;
		imageColour.r = 0.75f;
		imageColour.g = 0.0f;
		imageColour.b = 0.0f;
		imageColour.a = 0.35f;
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
		revealImage.SetActive(true);
		realityImage.SetActive(false);
		reverseImage.SetActive(false);
		noLenseImage.SetActive(false);
		revealWristImage.SetActive(true);
		realityWristImage.SetActive(false);
		reverseWristImage.SetActive(false);
		noLenseWristImage.SetActive(false);
		// Show Reveal Particles and Outlines
		particleAndOutlineManagerScript.DisplayRevealParticles();
		particleAndOutlineManagerScript.DisplayRevealOutlines();
		// Hide the other Particles and Outlines
		particleAndOutlineManagerScript.HideRealityParticles();
		particleAndOutlineManagerScript.HideRealityOutlines();
		particleAndOutlineManagerScript.HideReverseParticles();
		particleAndOutlineManagerScript.HideReverseOutlines();
	}
	private void GreenTint() {
		Color imageColour;
		imageColour.r = 0.0f;
		imageColour.g = 0.75f;
		imageColour.b = 0.0f;
		imageColour.a = 0.35f;
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
		revealImage.SetActive(false);
		realityImage.SetActive(false);
		reverseImage.SetActive(true);
		noLenseImage.SetActive(false);
		revealWristImage.SetActive(false);
		realityWristImage.SetActive(false);
		reverseWristImage.SetActive(true);
		noLenseWristImage.SetActive(false);
		// Show Reverse Particles and Outlines
		particleAndOutlineManagerScript.DisplayReverseParticles();
		particleAndOutlineManagerScript.DisplayReverseOutlines();
		// Hide the other Particles and Outlines
		particleAndOutlineManagerScript.HideRealityParticles();
		particleAndOutlineManagerScript.HideRealityOutlines();
		particleAndOutlineManagerScript.HideRevealParticles();
		particleAndOutlineManagerScript.HideRevealOutlines();
	}
	private void BlueTint() {
		Color imageColour;
		imageColour.r = 0.0f;
		imageColour.g = 0.0f;
		imageColour.b = 0.75f;
		imageColour.a = 0.35f;
		lensTintImage.color = imageColour;
		lensTintImage.enabled = true;
		revealImage.SetActive(false);
		realityImage.SetActive(true);
		reverseImage.SetActive(false);
		noLenseImage.SetActive(false);
		revealWristImage.SetActive(false);
		realityWristImage.SetActive(true);
		reverseWristImage.SetActive(false);
		noLenseWristImage.SetActive(false);
		// Show Reality Particles and Outlines
		particleAndOutlineManagerScript.DisplayRealityParticles();
		particleAndOutlineManagerScript.DisplayRealityOutlines();
		// Hide the other Particles and Outlines
		particleAndOutlineManagerScript.HideReverseParticles();
		particleAndOutlineManagerScript.HideReverseOutlines();
		particleAndOutlineManagerScript.HideRevealParticles();
		particleAndOutlineManagerScript.HideRevealOutlines();
	}
	private void NoLensTint() {
		lensTintImage.enabled = false;
		revealImage.SetActive(false);
		realityImage.SetActive(false);
		reverseImage.SetActive(false);
		noLenseImage.SetActive(true);
		revealWristImage.SetActive(false);
		realityWristImage.SetActive(false);
		reverseWristImage.SetActive(false);
		noLenseWristImage.SetActive(true);
		// Hide all Lens Particles and Outlines
		particleAndOutlineManagerScript.HideRevealParticles();
		particleAndOutlineManagerScript.HideRevealOutlines();
		particleAndOutlineManagerScript.HideReverseParticles();
		particleAndOutlineManagerScript.HideReverseOutlines();
		particleAndOutlineManagerScript.HideRealityParticles();
		particleAndOutlineManagerScript.HideRealityOutlines();
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
					NoLensTint();
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
		lensWheelAnimationManagerScript.previousLens = ((int)CurrentLens);
		Lens.LensList PreviousLens = CurrentLens;
		CurrentLens = NextLens;

		switch (CurrentLens) {
			case Lens.LensList.NONE: {
					NoLensTint();
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