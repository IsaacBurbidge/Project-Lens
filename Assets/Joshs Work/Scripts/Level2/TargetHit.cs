using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour {
	[SerializeField]
	private MeshRenderer lightMeshRenderer;
	[SerializeField]
	private Material successMaterial;
	[SerializeField]
	private AudioClip hitClip;

	// Plays an animation to open a door upon the Target being hit successfully with the ball
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			lightMeshRenderer.material = successMaterial;
			AudioSource.PlayClipAtPoint(hitClip, transform.position);
		}
	}
}