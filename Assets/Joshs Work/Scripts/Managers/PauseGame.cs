using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PauseGame : MonoBehaviour {
	[SerializeField]
	private InputActionProperty pauseGameButton;
	[SerializeField]
    private GameObject pauseMenuParent;
	[SerializeField]
	private GameObject pauseMenuOverlay;
	[SerializeField]
	private DynamicMoveProvider dynamicMoveProvider;

    void Update() {
		if (pauseGameButton.action.WasPressedThisFrame() == true) {
			Pause();
		}
	}
	// Display Pause Menu when the pause button is pressed on the VR Controller
	private void Pause() {
		pauseMenuParent.SetActive(true);
		pauseMenuOverlay.SetActive(true);
		dynamicMoveProvider.enabled = false;
	}
	// Called on Pause Menu Resume Button Press
	public void UnPause() {
		dynamicMoveProvider.enabled = true;
	}
}