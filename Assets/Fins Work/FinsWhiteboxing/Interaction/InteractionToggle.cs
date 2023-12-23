using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToggle : MonoBehaviour
{

    public bool interactGood;
    public Material interactGoodMaterial;

    public bool CheckMaterial()
    {
        if (gameObject.GetComponent<Material>() == interactGoodMaterial)
        {
            interactGood = true;
            return true;
        }
        else return false;
    }
}
