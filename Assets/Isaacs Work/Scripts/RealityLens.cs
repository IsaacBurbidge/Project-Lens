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
        TriggerVolume = transform.GetComponent<Collider>();
    }

    public override void ActivateLens() {
        if(CanSwapRoom) {
            switch (ActiveRoom) {
                case Rooms.Room1: {
					Room1.SetActive(false);
					Room2.SetActive(true);
                    ActiveRoom = Rooms.Room2;
					break;
                }
				case Rooms.Room2: {
					Room2.SetActive(false);
					Room1.SetActive(true);
					ActiveRoom = Rooms.Room1;
					break;
				}
			}
 
		}
    }

    public override void DeactivateLens() {
  //      if (CanSwapRoom) {
		//	switch (ActiveRoom) {
		//		case Rooms.Room1: {
		//			Room1.SetActive(false);
		//			Room2.SetActive(true);
		//			ActiveRoom = Rooms.Room2;
		//			break;
		//		}
		//		case Rooms.Room2: {
		//			Room2.SetActive(false);
		//			Room1.SetActive(true);
		//			ActiveRoom = Rooms.Room1;
		//			break;
		//		}
		//	}
		//}
    }

	private void OnTriggerEnter(Collider other) {
		CanSwapRoom = false;
	}

	private void OnTriggerExit(Collider other) {
		CanSwapRoom = true;
	}
}
