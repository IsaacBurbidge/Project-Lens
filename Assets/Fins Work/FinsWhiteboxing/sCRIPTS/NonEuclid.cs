using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NonEuclid : MonoBehaviour
{
    [SerializeField] private Eventy eventscript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            eventscript.isActive = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            eventscript.isActive = true;
        }
    }
}
