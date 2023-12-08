using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RealityLens : Lens{
    [SerializeField]
    private GameObject Room1;
    [SerializeField]
    private GameObject Room2;

    private void Start() {
        VisibleLens = LensList.REALITY;
        Room1 = transform.GetChild(0).gameObject;
        Room2 = transform.GetChild(1).gameObject;
    }

    public override void ActivateLens() {
        Room1.SetActive(false);
        Room2.SetActive(true);
    }

    public override void DeactivateLens() {
        Room1.SetActive(true);
        Room2.SetActive(false);
    }
}
