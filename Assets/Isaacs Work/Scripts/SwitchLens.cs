using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapLens : MonoBehaviour
{
	[SerializeField]
	private Lens.LensList CurrentLens = Lens.LensList.NONE;
	public void OnSwapLens() {
		switch (CurrentLens) { 
			case Lens.LensList.NONE: {
				CurrentLens = Lens.LensList.REVEAL;
				Debug.Log("reveal");
				break;
			}
			case Lens.LensList.REVEAL: {
				CurrentLens = Lens.LensList.REVERSE;
				Debug.Log("reverse");
				break;
			}
			case Lens.LensList.REVERSE: {
				CurrentLens = Lens.LensList.REALITY;
				Debug.Log("reality");
				break;
			}
			case Lens.LensList.REALITY: {
				CurrentLens = Lens.LensList.NONE;
				Debug.Log("none");
				break;
			}
		}

		Lens[] LensItems = (Lens[])FindObjectsOfType(typeof(Lens));
		for (int i = 0; i < LensItems.Length; i++) { 
			if(CurrentLens == LensItems[i].VisibleLens) {
				LensItems[i].ActivateLens();
			}else if ((int)CurrentLens-1 == (int)LensItems[i].VisibleLens) {
				LensItems[i].DeactivateLens();
			}
		}
	}
}
