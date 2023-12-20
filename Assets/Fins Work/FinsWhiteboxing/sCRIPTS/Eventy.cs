using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventy : MonoBehaviour
{

    [SerializeField] UnityEvent triggerEvent;

    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void triggerTheEvent()
    {
        triggerEvent.Invoke();
    }
}
