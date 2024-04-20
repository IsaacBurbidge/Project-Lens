using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RealityLens : Lens {
    [SerializeField]
    private GameObject Room1;
    [SerializeField]
    private GameObject Room2;
    [SerializeField]
    private Collider TriggerVolume;
	[SerializeField]
	private SwitchLens switchLensScript;

	enum Rooms {
        Room1,
        Room2
    }

    Rooms ActiveRoom = Rooms.Room1;

    public bool CanSwapRoom = true;

    private void Start() {
        VisibleLens = LensList.REALITY;
        Room1 = transform.GetChild(0).gameObject;
        Room2 = transform.GetChild(1).gameObject;
        //TriggerVolume = transform.GetComponent<Collider>();
    }

    public override void ActivateLens() {
        if(CanSwapRoom) {
            switch (ActiveRoom) {
                case Rooms.Room1: {
					if (Room1 != null && Room1 != null) {
						Room1.SetActive(false);
						Room2.SetActive(true);
						if (Room2.TryGetComponent(out MeshRenderer meshRenderer) == true) {
								Room2.GetComponent<MeshRenderer>().enabled = true;
						}
						ActiveRoom = Rooms.Room2;
					}
					break;
                }
				case Rooms.Room2: {
					if (Room1 != null && Room1 != null) {
						Room2.SetActive(false);
						Room1.SetActive(true);
						ActiveRoom = Rooms.Room1;
					}
					break;
				}
			}
 
		}
    }

    public override void DeactivateLens() {
		if (CanSwapRoom) {
			switch (ActiveRoom) {
				case Rooms.Room1: {
					if(Room1 != null && Room1 != null) {
						Room1.SetActive(false);
						Room2.SetActive(true);
						ActiveRoom = Rooms.Room2;
					}
					break;
				}
				case Rooms.Room2: {
					if (Room1 != null && Room1 != null) {
						Room2.SetActive(false);
						Room1.SetActive(true);
						ActiveRoom = Rooms.Room1;
					}		
					break;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.name == "Player") {
			if (switchLensScript.CurrentLens == LensList.REALITY) {
				CanSwapRoom = false;
			}
			else {
				CanSwapRoom = false;
			}
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.name == "Player") {
			if (switchLensScript.CurrentLens == LensList.REALITY) {
				CanSwapRoom = false;
			}
			else {
				CanSwapRoom = false;
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if (switchLensScript.CurrentLens == LensList.REALITY) {
			Room2.SetActive(true);
			Room1.SetActive(false);
			ActiveRoom = Rooms.Room2;
			CanSwapRoom = true;
		}
		else if(switchLensScript.CurrentLens != LensList.REALITY) {
			Room2.SetActive(false);
			Room1.SetActive(true);
			ActiveRoom = Rooms.Room1;
			CanSwapRoom = true;
		}
	}
}