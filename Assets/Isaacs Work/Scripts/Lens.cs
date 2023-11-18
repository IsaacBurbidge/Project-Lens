using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lens : MonoBehaviour {
	public LensList VisibleLens;

	public enum LensList {
		NONE = -1,
		REVEAL,
		REVERSE,
		REALITY
	}

	public virtual void ActivateLens() {

	}

	public virtual void DeactivateLens() { 
	
	}
}
