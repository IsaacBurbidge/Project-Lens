using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReset : MonoBehaviour
{
    [SerializeField] private GameObject resetObject;
    [SerializeField] Transform resetTransform;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == resetObject)
        {
            resetObject.transform.position = resetTransform.position;
            rb = resetObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }
}
