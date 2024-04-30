using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class LensWheel : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty toggleLensWheelButton;
	[SerializeField]
	private LensWheelAnimationManager lensWheelAnimationManagerScript;

	// Lens Wheel Variables
	private bool isLensWheelVisible = false;
    [SerializeField]
    private SwitchLens swapLensScript;
    [SerializeField]
    private GameObject lensWheelUI;

    void Start() {
        // Hide Lens Wheel on Start
        isLensWheelVisible = false;
        lensWheelUI.GetComponent<Canvas>().enabled = false;
        lensWheelUI.GetComponent<CanvasScaler>().enabled = false;
        lensWheelUI.GetComponent<GraphicRaycaster>().enabled = false;
        lensWheelUI.GetComponent<TrackedDeviceGraphicRaycaster>().enabled = false;
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
			lensWheelUI.GetComponent<Canvas>().enabled = true;
			lensWheelUI.GetComponent<CanvasScaler>().enabled = true;
			lensWheelUI.GetComponent<GraphicRaycaster>().enabled = true;
			lensWheelUI.GetComponent<TrackedDeviceGraphicRaycaster>().enabled = true;
			isLensWheelVisible = true;
            // Slow down time
            Time.timeScale = 0.15f;
            // Change to LensWheel state to ensure that no objects can be tagged as reversible when interacting with the Lens Wheel UI
            StateManager.currentState = StateManager.PlayerStates.LensWheel;
        }
        // Toggle Off
        else if (isLensWheelVisible == true) {
			// Hide Lens Wheel UI
			lensWheelUI.GetComponent<Canvas>().enabled = false;
			lensWheelUI.GetComponent<CanvasScaler>().enabled = false;
			lensWheelUI.GetComponent<GraphicRaycaster>().enabled = false;
			lensWheelUI.GetComponent<TrackedDeviceGraphicRaycaster>().enabled = false;
			isLensWheelVisible = false;
            // Revert to normal time
            Time.timeScale = 1.0f;
            // Revert back to Gameplay state
            StateManager.currentState = StateManager.PlayerStates.Gameplay;
        }
    }

    // Sets the Current Lens Enum to the chosen Lens [REVEAL | REVERSE | REALITY | NO LENS]
    public void ClickRevealLensBtn() {
		lensWheelAnimationManagerScript.PlayLensWheelAnimation();
		swapLensScript.LensWheelSwap(Lens.LensList.REVEAL);
    }
    public void ClickReverseLensBtn() {
		lensWheelAnimationManagerScript.PlayLensWheelAnimation();
		swapLensScript.LensWheelSwap(Lens.LensList.REVERSE);
    }
    public void ClickRealityLensBtn() {
		lensWheelAnimationManagerScript.PlayLensWheelAnimation();
		swapLensScript.LensWheelSwap(Lens.LensList.REALITY);
    }
    public void ClickNoLensBtn() {
		lensWheelAnimationManagerScript.PlayLensWheelAnimation();
		swapLensScript.LensWheelSwap(Lens.LensList.NONE);
    }
}