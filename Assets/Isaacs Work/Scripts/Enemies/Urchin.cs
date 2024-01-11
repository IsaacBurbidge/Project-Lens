using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Urchin : MonoBehaviour
{
	[SerializeField]
	private Vector3 TargetPos;

	private void Start() {
		TargetPos = transform.position + new Vector3(0,0,10);
	}

	private void Update() {
		
	}
}
