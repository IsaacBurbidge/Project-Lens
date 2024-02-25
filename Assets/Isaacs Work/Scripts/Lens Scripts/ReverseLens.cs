using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseLens : Lens {
	public Animator Animator;

	private void Start() {
		VisibleLens = LensList.REVERSE;
		//Animator = GetComponent<Animator>();
		//if (Animator == null ) {
			//Animator = transform.parent.GetComponent<Animator>();
		//}
	}

	public override void ActivateLens() {
		if (tag == "Reverse Object") {
			if (Animator != null) {
				Animator.SetBool("HasReversed",true);
			}
		}
	}

	public override void DeactivateLens() {
		if (tag == "Reverse Object" || tag == "Reverse Lens") {
			if (Animator != null) {
				Animator.SetBool("HasReversed", false);
			}
		}
	}
}
