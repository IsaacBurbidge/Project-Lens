using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclidToggler : Eventy
{
    public GameObject roomA;
    public GameObject roomB;

    public void EuclidToggle()
    {
        roomA.SetActive(!roomA.activeSelf);
        roomB.SetActive(!roomB.activeSelf);
    }
}
