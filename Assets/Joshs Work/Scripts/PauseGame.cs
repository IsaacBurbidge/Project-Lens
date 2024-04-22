using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour {
	[SerializeField]
	private InputActionProperty pauseGameButton;
	[SerializeField]
    private GameObject pauseMenuParent;

    // Update is called once per frame
    void Update() {
		if (pauseGameButton.action.WasPressedThisFrame() == true) {
			Pause();
		}
	}
    private void Pause() {
		pauseMenuParent.SetActive(true);
	}
}