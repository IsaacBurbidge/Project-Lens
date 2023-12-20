using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CycleLens : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty cycleLensButton;

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
                swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
                break;
            // Swap from Reveal Lens to Reverse Lens
            case Lens.LensList.REVEAL:
                swapLensScript.LensWheelSwap(Lens.LensList.REVERSE);
                break;
            // Swap from Reverse Lens to Reality Lens
            case Lens.LensList.REVERSE:
                swapLensScript.LensWheelSwap(Lens.LensList.REALITY);
                break;
            // Swap from Reality Lens to No Lens
            case Lens.LensList.REALITY:
                swapLensScript.LensWheelSwap(Lens.LensList.NONE);
                break;
            default:
                swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
                break;
        }
    }
}