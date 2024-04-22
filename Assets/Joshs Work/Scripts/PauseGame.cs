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
	private DynamicMoveProvider dynamicMoveProvider;

    // Update is called once per frame
    void Update() {
		if (pauseGameButton.action.WasPressedThisFrame() == true) {
			Pause();
		}
	}
    private void Pause() {
		pauseMenuParent.SetActive(true);
		dynamicMoveProvider.enabled = false;
	}
	// Called on Pause Menu Resume Button Press
	public void UnPause() {
		dynamicMoveProvider.enabled = true;
	}
}