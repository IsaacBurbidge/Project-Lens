using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchTrigger : MonoBehaviour
{
    public UnityEvent switchEvent;
    [SerializeField] string switchTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(switchTag))
        {
            switchEvent.Invoke();
        }
    }
}
