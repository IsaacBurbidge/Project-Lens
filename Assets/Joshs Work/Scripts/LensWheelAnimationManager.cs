using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensWheelAnimationManager : MonoBehaviour {
    [SerializeField]
    private SwitchLens switchLensScript;
	public int previousLens = -1;
	[SerializeField]
	private Animator Animator;

	public void PlayLensWheelAnimation() {
		switch (switchLensScript.CurrentLens) {
			// Check what the previous current lens was
			case Lens.LensList.NONE:
				if (previousLens == 0) {
					// PLAY REVEAL TO NO LENS ANIMATION
					Animator.SetInteger("AnimationInt", 4);
				}
				else if (previousLens == 1) {
					// PLAY REVERSE TO NO LENS ANIMATION
					Animator.SetInteger("AnimationInt", 10);
				}
				else if (previousLens == 2) {
					// PLAY REALITY TO NO LENS ANIMATION
					Animator.SetInteger("AnimationInt", 7);
				}
				break;
			case Lens.LensList.REVEAL:
				if (previousLens == -1) {
					// PLAY NO LENS TO REVEAL  ANIMATION
					Animator.SetInteger("AnimationInt", 1);
				}
				else if (previousLens == 1) {
					// PLAY REVERSE  TO REVEAL  ANIMATION
					Animator.SetInteger("AnimationInt", 11);
				}
				else if (previousLens == 2) {
					// PLAY REALITY TO REVEAL ANIMATION
					Animator.SetInteger("AnimationInt", 8);
				}
				break;
			case Lens.LensList.REVERSE:
				if (previousLens == -1) {
					// PLAY NO LENS TO REVERSE ANIMATION
					Animator.SetInteger("AnimationInt", 2);
				}
				else if (previousLens == 0) {
					// PLAY REVEAL TO REVERSE ANIMATION
					Animator.SetInteger("AnimationInt", 5);
				}
				else if (previousLens == 2) {
					// PLAY REALITY TO REVERSE ANIMATION
					Animator.SetInteger("AnimationInt", 9);
				}
				break;
			case Lens.LensList.REALITY:
				if (previousLens == -1) {
					// PLAY NO LENS TO REALITY ANIMATION 
					Animator.SetInteger("AnimationInt", 3);
				}
				else if (previousLens == 0) {
					// PLAY REVEAL TO REALITY ANIMATION 
					Animator.SetInteger("AnimationInt", 6);
				}
				else if (previousLens == 1) {
					// PLAY REVERSE TO REALITY ANIMATION
					Animator.SetInteger("AnimationInt", 12);
				}
				break;
		}

    }
}