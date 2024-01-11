using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lens : MonoBehaviour {
	//The lens that this object is visible/editiable under
	public LensList VisibleLens;

	//List of lens types
	public enum LensList {
		NONE = -1,
		REVEAL,
		REVERSE,
		REALITY
	}

	//Functionallity declared in child classes
	public virtual void ActivateLens() {

	}

	public virtual void DeactivateLens() { 
	
	}
}
