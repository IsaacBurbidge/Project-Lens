using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealTutorialFix : MonoBehaviour {

    [SerializeField]
    private SwitchLens swapLensScript;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void LensSwitch() {
        if (NonEuclid.inRoom == false) {
            switch (swapLensScript.CurrentLens) {
                case Lens.LensList.NONE:
                    gameObject.SetActive(false);
                    break;
                case Lens.LensList.REVEAL:
                    gameObject.SetActive(true);
                    break;
                case Lens.LensList.REVERSE:
                    gameObject.SetActive(false);
                    break;
                case Lens.LensList.REALITY:
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}