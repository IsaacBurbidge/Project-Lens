using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	[SerializeField]
	private bool IsFixed = false;
	[SerializeField]
	private GameObject TopOfLever;

	[SerializeField]
	private Animator Animator;

	private void Start() {
		Animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other) {
		if (!IsFixed && other.tag == "Fix") {
			TopOfLever.SetActive(true);
			Destroy(other.gameObject);
			Animator.SetBool("IsFixed",true);
		}
	}
}
