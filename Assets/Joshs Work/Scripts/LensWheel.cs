using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using static StateManager;

public class LensWheel : MonoBehaviour {
    [SerializeField]
    private SwapLens swapLensScript;
    [SerializeField]
    private GameObject lensWheelUI;
    public bool isLensWheelVisible = false;

    // Press 'F' key to toggle Lens Wheel On/Off
    public void OnToggleLensWheel() {
        // Toggle On
        if(isLensWheelVisible == false) {
            lensWheelUI.SetActive(true);
            isLensWheelVisible = true;
            Time.timeScale = 0.15f;
            Cursor.lockState = CursorLockMode.Confined;
            currentState = PlayerStates.LensWheel;
        }
        // Toggle Off
        else if (isLensWheelVisible == true) {
            lensWheelUI.SetActive(false);
            isLensWheelVisible = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            currentState = PlayerStates.Gameplay;
        }
    }
    // Sets the Current Lens Enum - Picks the Lens before the one chosen due to the cycle feature in SwitchLens.cs script
    // Calls the OnSwapLens Function to display the correct Current Lens Text
    public void ClickRevealLensBtn() {
        swapLensScript.CurrentLens = Lens.LensList.NONE;
        swapLensScript.OnSwapLens();
    }
    public void ClickReverseLensBtn() {
        swapLensScript.CurrentLens = Lens.LensList.REVEAL;
        swapLensScript.OnSwapLens();
    }
    public void ClickRealityLensBtn() {
        swapLensScript.CurrentLens = Lens.LensList.REVERSE;
        swapLensScript.OnSwapLens();
    }
    public void ClickNoLensBtn() {
        swapLensScript.CurrentLens = Lens.LensList.REALITY;
        swapLensScript.OnSwapLens();
    }
}