using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReset : MonoBehaviour
{
    [SerializeField] private GameObject resetObject;
    [SerializeField] Transform resetTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == resetObject)
        {
            resetObject.transform.position = resetTransform.position;
        }
    }
}
