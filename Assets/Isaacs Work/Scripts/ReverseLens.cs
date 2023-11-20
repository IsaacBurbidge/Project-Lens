using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseLens : Lens {
	public Animator animator;

	private void Start() {
		VisibleLens = LensList.REVERSE;
		animator = GetComponent<Animator>();
	}

	public override void ActivateLens() {
		if (tag == "Reverse Object") {
			if (animator != null) {
				animator.SetBool("HasReversed",true);
			}
		}
	}

	public override void DeactivateLens() {
		if (tag == "Reverse Object" || tag == "Reverse Lens") {
			if (animator != null) {
				animator.SetBool("HasReversed", false);
			}
		}
	}
}
