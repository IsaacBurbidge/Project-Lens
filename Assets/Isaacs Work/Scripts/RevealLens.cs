using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealLens : Lens {
	MeshRenderer Mesh;
	Rigidbody Rigidbody;
	Collider Collider;

	private void Start() {
		VisibleLens = LensList.REVEAL;
		Mesh = GetComponent<MeshRenderer>();
		Rigidbody = GetComponent<Rigidbody>();
		Collider = GetComponent<Collider>();
		Mesh.enabled = false;
		if (Collider != null) {
			Collider.enabled = false;
		}
		if (Rigidbody != null) {
			Rigidbody.Sleep();
		}
	}

	public override void ActivateLens() {
		Mesh.enabled = true;
		if (Collider != null) { 
			Collider.enabled = true;
		}
		if (Rigidbody != null) {
			Rigidbody.WakeUp();
		}
	}

	public override void DeactivateLens() {
		Mesh.enabled = false;
		if (Collider != null) {
			Collider.enabled = false;
		}
		if (Rigidbody != null) {
			Rigidbody.Sleep();
		}
	}
}
