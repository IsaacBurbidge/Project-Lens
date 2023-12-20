using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerSprint : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty sprintButton;
    public bool isSprinting = false;

    [SerializeField]
    private ContinuousMoveProviderBase continuousMoveProviderBase;

    // Start is called before the first frame update
    void Start() {
        isSprinting = false;
    }

    // Update is called once per frame
    void Update() {
        if (sprintButton.action.WasPressedThisFrame() == true) {
            ToggleSprint();
        }
    }

	private void ToggleSprint() {
        if(isSprinting == true) {
            // Change to Walking Speed
            continuousMoveProviderBase.moveSpeed = 1.5f;
            isSprinting = false;
        }
        else if(isSprinting == false) {
            // Change to Sprinting Speed
            continuousMoveProviderBase.moveSpeed = 3.0f;
            isSprinting = true;
        }
    }
}