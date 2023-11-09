using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventy : MonoBehaviour
{

    [SerializeField] UnityEvent triggerEvent;
    [SerializeField] KeyCode triggerKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(triggerKey))
        {
            triggerEvent.Invoke();
        }
    }

}
