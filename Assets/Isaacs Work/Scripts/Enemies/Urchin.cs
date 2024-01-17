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
	[SerializeField]
	private Vector3 Angle1;
	[SerializeField]
	private Vector3 Angle2;

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

	void VisionCone() {
		float DotProduct = (Angle1.x*Angle2.x)+ (Angle1.y*Angle2.y) + (Angle2.z*Angle2.z);
		
	}

	private void OnDrawGizmos() {
		Gizmos.DrawLine(transform.position, Angle1);
		Gizmos.DrawLine(transform.position, Angle2);
	}
}
