using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour {
	[SerializeField]
	private Animator firstDoorAnimator;
	[SerializeField]
	private Animator secondDoorAnimator;
	[SerializeField]
	private GameObject leverHandle;
	[SerializeField]
	private TextMeshProUGUI lockedDoor;
	// Start is called before the first frame update
	void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		if (Keyboard.current.digit1Key.isPressed) {
			leverHandle.SetActive(true);
			lockedDoor.text = "Give it a try now!";


		}

		if (Keyboard.current.digit2Key.isPressed) {
			firstDoorAnimator.SetBool("IsOpen", true);
		}

		if (Keyboard.current.digit3Key.isPressed) {
			secondDoorAnimator.SetBool("IsOpen", true);
		}

	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			


		}
	}
}