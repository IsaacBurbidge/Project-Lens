using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclidToggler : Eventy
{
    public GameObject roomA;
    public GameObject roomB;

    [SerializeField]
    private SwitchLens swapLensScript;

    public void EuclidToggle()
    {
        switch (swapLensScript.CurrentLens) {
            case Lens.LensList.NONE:
                roomA.SetActive(true);
                roomB.SetActive(false);
                break;
            case Lens.LensList.REVEAL:
                roomA.SetActive(true);
                roomB.SetActive(false);
                break;
            case Lens.LensList.REVERSE:
                roomA.SetActive(true);
                roomB.SetActive(false);
                break;
            case Lens.LensList.REALITY:
                roomA.SetActive(false);
                roomB.SetActive(true);
                break;
        }
        //roomA.SetActive(!roomA.activeSelf);
        //roomB.SetActive(!roomB.activeSelf);
    }
}
