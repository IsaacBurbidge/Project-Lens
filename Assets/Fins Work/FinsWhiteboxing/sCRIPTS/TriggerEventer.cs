using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventer : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    [SerializeField] public UnityEvent triggerEvent;
    [SerializeField] AudioClip triggerClip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(triggerTag))
        {
            Debug.Log("Triggered");
            triggerEvent.Invoke();
            AudioSource.PlayClipAtPoint(triggerClip, transform.position);
        }
    }
}
