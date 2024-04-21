using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridgeTagCheck : MonoBehaviour {
    [SerializeField]
    private GameObject leftFallingBridgeObject;
	[SerializeField]
	private GameObject rightFallingBridgeObject;
    void Update() {
        // Only plays Bridge Fix animation if both bridge pieces are tagged as reversable
        if (leftFallingBridgeObject.CompareTag("Reverse Object") && rightFallingBridgeObject.CompareTag("Reverse Object")) {
            GetComponent<ReverseLens>().Animator.SetBool("BothReverseTagged", true);
        }
        else {
			GetComponent<ReverseLens>().Animator.SetBool("BothReverseTagged", false);
		}
    }
}