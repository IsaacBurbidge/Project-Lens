using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Urchin : MonoBehaviour {
	[SerializeField]
	public Vector3 TargetPos;
	[SerializeField]
	private Vector3 InitialPos;
	[SerializeField]
	private NavMeshAgent Agent;
	bool MovingToTarget = true;
	public Vector3 AmountToMove;

	public bool AttackPlayer = false;

	private void Start() {
		Agent = GetComponent<NavMeshAgent>();
		InitialPos = transform.position;
		TargetPos = transform.position + AmountToMove;
		Agent.SetDestination(TargetPos);
	}

	private void Update() {
		Wander();
	}

	private void Wander() {
		if (AttackPlayer) {

		} else if (Agent.remainingDistance == 0) {
			if (transform.position.x == InitialPos.x && transform.position.z == InitialPos.z) {
				Agent.SetDestination(TargetPos);
				MovingToTarget = true;
			} else {
				Agent.SetDestination(InitialPos);
				MovingToTarget = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "PressurePlate") {

		} else {
			if (MovingToTarget) {
				Agent.SetDestination(InitialPos);
				MovingToTarget = false;
			} else {
				Agent.SetDestination(TargetPos);
				MovingToTarget = true;
			}
		}
	}
}
