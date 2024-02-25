using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCheck : MonoBehaviour {
    public bool isSensorLit;
	public Material sensorLitMaterial;
    public bool dropLeverHandle;
    [SerializeField]
    private GameObject leverHandleObj;

	public void CheckSensors() {
        SensorCheck[] sensorsArray = FindObjectsOfType<SensorCheck>();
        foreach (SensorCheck sensor in sensorsArray) { 
            if(sensor.isSensorLit == true) {
                dropLeverHandle = true;
                Debug.Log("Yes");
            }
            else {
                dropLeverHandle = false;
				Debug.Log("No");
				break;
            }
        }
        if(dropLeverHandle == true) {
			leverHandleObj.SetActive(true);

		}
	}


	// Start is called before the first frame update
	void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

}
