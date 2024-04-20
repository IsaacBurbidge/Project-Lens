using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchTrigger : MonoBehaviour
{
    public UnityEvent switchEvent;
    [SerializeField] string switchTag;
    [SerializeField] AudioClip switchHitClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(switchTag))
        {
            AudioSource.PlayClipAtPoint(switchHitClip, transform.position);
            switchEvent.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
