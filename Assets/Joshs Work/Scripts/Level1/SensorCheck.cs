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
        // Checks if all 3 sensors are lit up and if so, drops the lever hand piece
        SensorCheck[] sensorsArray = FindObjectsOfType<SensorCheck>();
        foreach (SensorCheck sensor in sensorsArray) { 
            if(sensor.isSensorLit == true) {
                dropLeverHandle = true;
            }
            else {
                dropLeverHandle = false;
				break;
            }
        }
        if(dropLeverHandle == true) {
			leverHandleObj.SetActive(true);
		}
	}
}