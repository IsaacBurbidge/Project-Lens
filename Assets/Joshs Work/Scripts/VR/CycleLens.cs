using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CycleLens : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty cycleLensButton;
	[SerializeField]
	private LensWheelAnimationManager lensWheelAnimationManagerScript;

	// Misc Variables
	[SerializeField]
    private SwitchLens swapLensScript;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (cycleLensButton.action.WasPressedThisFrame() == true) {
            SwapLens();
        }
    }

    // Press 'Y' Button on Left XR Controller to Swap Lens in this order: NO LENS -> REVEAL LENS -> REVERSE LENS -> REALITY LENS -> then return to NO LENS
    private void SwapLens() {

		switch (swapLensScript.CurrentLens) {
            // Swap from No Lens to Reveal Lens
            case Lens.LensList.NONE:
				lensWheelAnimationManagerScript.previousLens = -1;
				swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
				lensWheelAnimationManagerScript.PlayLensWheelAnimation();
				break;
            // Swap from Reveal Lens to Reverse Lens
            case Lens.LensList.REVEAL:
				lensWheelAnimationManagerScript.previousLens = 0;
				swapLensScript.LensWheelSwap(Lens.LensList.REVERSE);
				lensWheelAnimationManagerScript.PlayLensWheelAnimation();
				break;
            // Swap from Reverse Lens to Reality Lens
            case Lens.LensList.REVERSE:
				lensWheelAnimationManagerScript.previousLens = 1;
				swapLensScript.LensWheelSwap(Lens.LensList.REALITY);
				lensWheelAnimationManagerScript.PlayLensWheelAnimation();
				break;
            // Swap from Reality Lens to No Lens
            case Lens.LensList.REALITY:
				lensWheelAnimationManagerScript.previousLens = 2;
				swapLensScript.LensWheelSwap(Lens.LensList.NONE);
				lensWheelAnimationManagerScript.PlayLensWheelAnimation();
				break;
            default:
                swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
                break;
        }

    }
}