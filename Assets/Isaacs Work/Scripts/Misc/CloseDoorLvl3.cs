using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseDoorLvl3 : MonoBehaviour
{
	[SerializeField]
	Animator Door;

	private void OnTriggerEnter(Collider other) {
		Door.SetBool("IsClosing", true);
	}

	private void OnTriggerExit(Collider other) {
		Door.SetBool("IsClosing", false);
	}

}
