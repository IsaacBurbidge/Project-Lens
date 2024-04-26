using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrip : MonoBehaviour
{
    [SerializeField] 
    string leftHand;
	[SerializeField]
	string rightHand;
	[SerializeField] 
    GameObject playerObject;
    [SerializeField] GameObject resetLocation;
    [SerializeField] AudioClip clipToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(leftHand) || other.CompareTag(rightHand))
        {
			playerObject.transform.position = resetLocation.transform.position;
            AudioSource.PlayClipAtPoint(clipToPlay, playerObject.transform.position);
        }
    }
}
