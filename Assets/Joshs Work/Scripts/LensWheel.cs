using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LensWheel : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty toggleLensWheelButton;

    // Lens Wheel Variables
    private bool isLensWheelVisible = false;
    [SerializeField]
    private SwitchLens swapLensScript;
    [SerializeField]
    private GameObject lensWheelUI;

    void Start() {
        // Hide Lens Wheel on Start
        isLensWheelVisible = false;
        lensWheelUI.SetActive(false);
    }

    void Update() {
        if (toggleLensWheelButton.action.WasPressedThisFrame() == true) {
            ToggleLensWheel();
        }
    }

    // Press X Button on Left XR Controller to toggle Lens Wheel On/Off
    private void ToggleLensWheel() {
        // Toggle On
        if (isLensWheelVisible == false) {
            // Show Lens Wheel UI
            lensWheelUI.SetActive(true);
            isLensWheelVisible = true;
            // Slow down time
            Time.timeScale = 0.15f;
        }
        // Toggle Off
        else if (isLensWheelVisible == true) {
            // Hide Lens Wheel UI
            lensWheelUI.SetActive(false);
            isLensWheelVisible = false;
            // Revert to normal time
            Time.timeScale = 1.0f;
        }
    }

    // Sets the Current Lens Enum to the chosen Lens [REVEAL | REVERSE | REALITY | NO LENS]
    public void ClickRevealLensBtn() {
        swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
    }
    public void ClickReverseLensBtn() {
        swapLensScript.LensWheelSwap(Lens.LensList.REVERSE);
    }
    public void ClickRealityLensBtn() {
        swapLensScript.LensWheelSwap(Lens.LensList.REALITY);
    }
    public void ClickNoLensBtn() {
        swapLensScript.LensWheelSwap(Lens.LensList.NONE);
    }
}
