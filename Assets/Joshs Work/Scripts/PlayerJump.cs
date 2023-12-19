using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour {
	// Player
	private Vector3 verticalVelocity;
	public float jumpHeight = 1.2f;
	public float gravity = -15.0f;

	// Player Input
	[SerializeField]
	private InputActionProperty jumpButton;
	[SerializeField]
	private CharacterController characterController;
	public bool jump;

	// Player Grounded
	public bool grounded = true;
	public float groundedOffset = -0.14f;
	public float groundedRadius = 0.1f;
	public LayerMask groundLayers;

	// Update is called once per frame
	void Update() {
		GroundedCheck();

		if (jumpButton.action.WasPressedThisFrame() && grounded == true) {
			Jump();
		}
		verticalVelocity.y += gravity * Time.deltaTime;

		characterController.Move(verticalVelocity * Time.deltaTime);
	}

	private void GroundedCheck() {
		// set sphere position, with offset
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
	}
	private void Jump() {
		// Calculates how much velocity is needed to reach desired height
		verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
	}
}