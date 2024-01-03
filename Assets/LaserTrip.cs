using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrip : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] GameObject resetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            other.gameObject.transform.position = resetLocation.transform.position;
        }
    }
}
