using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour {
	[SerializeField]
	private MeshRenderer lightMeshRenderer;
	[SerializeField]
	private Material successMaterial;


	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			Debug.Log("Triggered");
			lightMeshRenderer.material = successMaterial;
		}
	}
}
