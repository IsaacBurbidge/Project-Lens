using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Urchin : MonoBehaviour
{
	[SerializeField]
	private Vector3 TargetPos;
	[SerializeField]
	private Vector3 InitialPos;
	[SerializeField]
	private NavMeshAgent Agent;

	private void Start() {
		Agent = GetComponent<NavMeshAgent>();
		InitialPos = transform.position;
		TargetPos = transform.position + new Vector3(0,0,10);
		Agent.SetDestination(TargetPos);
	}

	private void Update() {
		Wander();
	}

	private void Wander() {

		if (Agent.remainingDistance == 0) {
			if (transform.position == InitialPos) {
				Agent.SetDestination(TargetPos);
			} else {
				Agent.SetDestination(InitialPos);
			}
		}
	} 
}
