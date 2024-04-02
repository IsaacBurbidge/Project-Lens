using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventer : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    [SerializeField] public UnityEvent triggerEvent; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(triggerTag))
        {
            Debug.Log("Triggered");
            triggerEvent.Invoke();
        }
    }
}
