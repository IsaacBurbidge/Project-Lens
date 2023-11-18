using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealLens : Lens {
	private void Start() {
		VisibleLens = LensList.REVEAL;
		GetComponent<MeshRenderer>().enabled = false;
	}

	public override void ActivateLens() {
		GetComponent<MeshRenderer>().enabled = true;
	}

	public override void DeactivateLens() {
		GetComponent<MeshRenderer>().enabled = false;
	}
}
