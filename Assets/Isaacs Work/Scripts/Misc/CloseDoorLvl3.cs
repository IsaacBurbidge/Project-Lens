using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseDoorLvl3 : MonoBehaviour
{
	[SerializeField]
	Animator Door;

	[SerializeField]
	AudioPlayer player;

	private void OnTriggerEnter(Collider other) {
		Door.SetBool("IsClosing", true);
		player.PlaySound();
	}

	private void OnTriggerExit(Collider other) {
		Door.SetBool("IsClosing", false);
		player.PlaySound();
	}

}
