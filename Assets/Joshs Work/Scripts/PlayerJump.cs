using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour {
	// Player
	private Vector3 verticalVelocity;
	public float jumpHeight = 1.2f;
	public float gravity = -15.0f;
	private float terminalVelocity = 53.0f;

	// Player Input
	[SerializeField]
	private InputActionProperty jumpButton;
	[SerializeField]
	private CharacterController characterController;

	// Player Grounded
	public bool isGrounded = true;
	public float groundedOffset = -0.14f;
	public float groundedRadius = 0.1f;
	public LayerMask groundLayers;

	// Timeouts
	public float jumpTimeout = 0.1f;
	public float fallTimeout = 0.15f;

	// Timeout deltatime
	private float jumpTimeoutDelta;
	private float fallTimeoutDelta;

	private void Start() {
		// Reset our timeouts on start
		jumpTimeoutDelta = jumpTimeout;
		fallTimeoutDelta = fallTimeout;
	}

	// Update is called once per frame
	void Update() {
		GroundedCheck();

		if (jumpButton.action.WasPressedThisFrame() == true && isGrounded == true) {
			PerformJump();
		}

		ApplyJump();
	}

	// Only Jump if on a Ground Layer 
	private void GroundedCheck() {
		// Set sphere position, with an offset
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		// Check if the Sphere is colliding with a Ground Layer
		isGrounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
	}

	public void PerformJump() {
		if (isGrounded) {
			fallTimeoutDelta = fallTimeout;

			// Stop our velocity dropping infinitely when grounded
			if (verticalVelocity.y < 0.0f) {
				verticalVelocity.y = -1f;
			}

			// Jump
			if (jumpButton.action.WasPressedThisFrame() == true) {
				// Calculates how much velocity is needed to reach desired height
				verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			}

			// Jump timeout - adds buffer time between jumps
			if (jumpTimeoutDelta >= 0.0f) {
				jumpTimeoutDelta -= Time.deltaTime;
			} 
			else {
				// Reset the jump timeout timer
				jumpTimeoutDelta = jumpTimeout;

				// Fall timeout
				if (fallTimeoutDelta >= 0.0f) {
					fallTimeoutDelta -= Time.deltaTime;
				}
			}
		}
	}
	public void ApplyJump() {
		// Apply gravity over time if under terminalVeclocity (multiply by delta time twice to linearly speed up over time)
		if (verticalVelocity.y < terminalVelocity) {
			verticalVelocity.y += gravity * Time.deltaTime;
		}
		// Move the Character Controller using the jump force
		characterController.Move(new Vector3(0.0f, verticalVelocity.y, 0.0f) * Time.deltaTime);
	}
}