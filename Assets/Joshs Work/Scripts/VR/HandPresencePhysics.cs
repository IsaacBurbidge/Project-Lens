using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;

    void Start() {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }
  

    public void EnableHandColliderDelay(float delay) {
        Invoke("EnableHandCollider", delay);
	}

    // Re-enables all colliders inside the bones of a hand after you stop interacting with an object
    public void EnableHandCollider() {
        foreach(Collider itemCollider in handColliders) {
            itemCollider.enabled = true;
		}
	}
    // Disables all colliders inside the bones of a hand after you start interacting with an object
    public void DisableHandCollider() {
        foreach (Collider itemCollider in handColliders) {
            itemCollider.enabled = false;
        }
    }

    // Fixed Update is called once per physics frame
    void FixedUpdate() {
        // Position of Hand with Physics
        // Stops hands going through objects
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        // Rotation with Physics
        // Hands rotate relative to XR Controller
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        // Find the rotation
        Vector3 rotationDifferenceInDegrees = angleInDegree * rotationAxis;

        // Rotate the Hand by converting to Radians
        rb.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}