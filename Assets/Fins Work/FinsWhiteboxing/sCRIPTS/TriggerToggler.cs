using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggler : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    public Animator animator;
    public string triggerName;
    [SerializeField] private AudioClip triggerClip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(triggerTag))
        {
            Debug.Log("Triggered"); 
            animator.SetTrigger(triggerName);
            AudioSource.PlayClipAtPoint(triggerClip, transform.position);
        }
    }
}
