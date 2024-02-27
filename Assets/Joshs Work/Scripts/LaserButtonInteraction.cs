using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Lens;

public class LaserButtonInteraction : Lens {
	[SerializeField]
	private GameObject laserObject;


	// Start is called before the first frame update
	void Start() {
		VisibleLens = LensList.REVEAL;
	}

    // Update is called once per frame
    void Update() {
        
    }
	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand")) {
            Debug.Log("Turn off Lasers");
		}
	}
}