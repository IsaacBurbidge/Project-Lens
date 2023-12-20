using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TagReversibleObjects : MonoBehaviour {
    // Player Input
    [SerializeField]
    private InputActionProperty reversibleTagLeftButton;
    [SerializeField]
    private InputActionProperty reversibleTagRightButton;

    // Player Hand Objects
    [SerializeField]
    private GameObject leftHandObject;
    [SerializeField]
    private GameObject rightHandObject;

    //  Materials
    [SerializeField]
    private List<Material> previousMatList;
    [SerializeField]
    private Material reversibleMat;

    // Ray Interactor Script References
    [SerializeField]
    private XRRayInteractor leftHandRayInteractor;
    [SerializeField]
    private XRRayInteractor rightHandRayInteractor;

    // Misc
    public List<GameObject> reversibleObjectsList;
    public int objectToRemoveIndex;
    private RaycastHit hit;
    private int maxSizeOfList = 3;
    [SerializeField]
    private SwitchLens swapLensScript;
   

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (StateManager.currentState == StateManager.PlayerStates.Gameplay){
            if (reversibleTagLeftButton.action.WasPressedThisFrame() == true) {
                GetLeftHandRayCastHit(hit);
                CheckObjectsTag(hit);
            }
            else if (reversibleTagRightButton.action.WasPressedThisFrame() == true) {
                GetRightHandRayCastHit(hit);
                CheckObjectsTag(hit);
            }
        }
    }

    // Checks if the Object hit with the ray is reversible or not.
    public void CheckObjectsTag(RaycastHit hit) {
        // Checks if the reversibleObjectsList already contains the Object that the ray hit
        if (reversibleObjectsList.Contains(hit.transform.gameObject) == true) {
            // Retrieves the objects index that is going to be removed from the List - helps with reassigning its previous material
            objectToRemoveIndex = reversibleObjectsList.IndexOf(hit.transform.gameObject);
            // Removes Object from the List
            reversibleObjectsList.Remove(hit.transform.gameObject);

            // Reverts the tag back to the Reverse Lens default tag
            hit.transform.gameObject.tag = "Reverse Lens";
            // Changes Color of Object Material back to its Previous Material 
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = previousMatList[objectToRemoveIndex];
            previousMatList.Remove(previousMatList[objectToRemoveIndex]);

            //if (GetComponent<SwitchLens>() != null && GetComponent<SwitchLens>().CurrentLens == Lens.LensList.REVERSE) {
            //	hit.transform.GetComponent<ReverseLens>().DeactivateLens();
            // }

        } 
        // Checks that the Object is not already inside the reversibleObjectsList and that it does contain the 'Reverse Lens' tag
        else if (reversibleObjectsList.Contains(hit.transform.gameObject) == false && hit.transform.CompareTag("Reverse Lens") == true) {
            // Check if the List has reached max capacity
            if (reversibleObjectsList.Count == maxSizeOfList) {
                // Display Error Message: Must remove an object from being reversible | Max is only 3
                Debug.Log("Max Objects that can be Reversible are 3. Please remove an object from being reversible");
            }
            // Check if the List hasn't reached max capacity
            else if (reversibleObjectsList.Count < maxSizeOfList) {
                TagObject();

                //if (GetComponent<SwitchLens>() != null && GetComponent<SwitchLens>().CurrentLens == Lens.LensList.REVERSE) {
                //    hit.transform.GetComponent<ReverseLens>().ActivateLens();
                //}
            }
		} 
        // The Object cannot be tagged as reversible in the Level so do nothing
        else {
            Debug.Log("This Object is un-able to be tagged as reversible");
		}
    }

    // Return the Object that the Left Hand Raycast has hit
    private RaycastHit GetLeftHandRayCastHit(RaycastHit leftHit) {
        leftHandRayInteractor.TryGetCurrent3DRaycastHit(out hit);
        return leftHit;
	}
    // Return the Object that the Right Hand Raycast has hit
    private RaycastHit GetRightHandRayCastHit(RaycastHit rightHit) {
        rightHandRayInteractor.TryGetCurrent3DRaycastHit(out hit);
        return rightHit;
    }

    // Checks if the Object hit with the ray is reversible or not.
    private void TagObject() {
        // Adds Object to the List
        reversibleObjectsList.Add(hit.transform.gameObject);

        // Changes the tag to the Reverse Object tag - allows the object to be reversed
        hit.transform.gameObject.tag = "Reverse Object";
        // Saves the Objects Material in an array so it can revert back to its material once it is un-tagged
        previousMatList.Add(hit.transform.gameObject.GetComponent<MeshRenderer>().material);
        // Changes Color of Object Material to Reversible Material
        hit.transform.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;
    }
}