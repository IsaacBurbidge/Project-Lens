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
    private List<Material> previousParentMatList;
    [SerializeField]
    private Material reversibleMat;

    // Ray Interactor Script References
    [SerializeField]
    private XRRayInteractor leftHandRayInteractor;
    [SerializeField]
    private XRRayInteractor rightHandRayInteractor;

    // Misc
    public List<GameObject> reversibleObjectsList;
    private int objectToRemoveIndex;
    private RaycastHit hit;
    private int maxSizeOfList = 100;
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
            // Changes Color of Parent Object Material back to its Previous Material 
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = previousParentMatList[objectToRemoveIndex];
            // Revert the Reverse state as it has been untagged
            hit.transform.gameObject.GetComponent<ReverseLens>().DeactivateLens();

            // Check if object has any children
            if (hit.transform.childCount > 0) {
                RevertChildrenLogic();
            }

            // Remove the material from the list
            previousParentMatList.Remove(previousParentMatList[objectToRemoveIndex]);
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


    // Checks to see if the object being tagged is a child of an object that is able to be reversed
    private void CheckParent() {
        // Has a parent with a reversible tag
        if (hit.transform.parent.gameObject.CompareTag("Reverse Lens")) {
            // Adds the Parent Object to the List
            reversibleObjectsList.Add(hit.transform.parent.gameObject);
            ReverseTagParentLogic();
            Debug.Log("1");
		} 
        // Has children and none of them contains a particle system
        else if (hit.transform.childCount > 0 && hit.transform.gameObject.GetComponentInChildren<ParticleSystem>() == null) {
			// Adds this Object to the List
			reversibleObjectsList.Add(hit.transform.gameObject);
            ReverseTagObjectLogic();
            ChangeChildrensMaterial();
            ChangeChildrensTag();
			Debug.Log("2");
		}
        // Doesn't have a parent with a reversible tag
        else if (hit.transform.parent.gameObject.CompareTag("Reverse Object") == true) {
            Transform[] childrenArray = null;
            // Get each child and store them in an array
            childrenArray = hit.transform.parent.gameObject.GetComponentsInChildren<Transform>();

            // Revert material and tag for every child object
            foreach (Transform childObj in childrenArray) {
                childObj.transform.gameObject.GetComponent<MeshRenderer>().material = previousParentMatList[objectToRemoveIndex];
                childObj.transform.gameObject.tag = "Reverse Lens";
            }
			Debug.Log("3");
		}
        // Doesn't have a parent with a reversible tag and has no children
        else {
            // Adds this Object to the List
            reversibleObjectsList.Add(hit.transform.gameObject);
            ReverseTagObjectLogic();
			Debug.Log("Add pdsaaredsant from child");
			Debug.Log("Add pdsaaredsant from child 4");
		}
        if (swapLensScript.CurrentLens == Lens.LensList.REVERSE) {
			// Reverse the object if the Reverse Lens is active and this object was just tagged as reversable)
			hit.transform.gameObject.GetComponent<ReverseLens>().ActivateLens();
		}
	}

    // Tagged a Child so: Change the material of all the Parents children to the reverse one
    private void ChangeParentChildrensMaterial() {
        Transform[] parentChildrenArray = null;

        // Get each child from the parent and store them in an array
        parentChildrenArray = hit.transform.parent.GetComponentsInChildren<Transform>();

        // Assigns the Reverse Object Material to every child object
        foreach (Transform childObj in parentChildrenArray) {
            childObj.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;
        }
    }

    // Tagged a Parent: Change the material of all its children to the reverse one
    private void ChangeChildrensMaterial() {
        Transform[] childrenArray = null;

        // Get each child and store them in an array
        childrenArray = hit.transform.GetComponentsInChildren<Transform>();

        // Assigns the Reverse Object Material to every child object
        foreach (Transform childObj in childrenArray) {
            childObj.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;
        }
    }

    // Tagged a Parent: Change the tag of all its children to the reverse one
    private void ChangeChildrensTag() {
        Transform[] childrenArray = null;

        // Get each child store them in an array
        childrenArray = hit.transform.GetComponentsInChildren<Transform>();

        // Assigns the Reverse tag to every child object
        foreach (Transform childObj in childrenArray) {
            childObj.transform.gameObject.tag = "Reverse Object";
        }
    }


    // Reverts all childrens material and tag back to the   ir previous ones once a parent object has been untagged as reversible
    private void RevertChildrenLogic() {
        Transform[] childrenArray = null;

        // Get each child and store them in an array
        childrenArray = hit.transform.gameObject.GetComponentsInChildren<Transform>();

        // Revert material and tag for every child object
        foreach (Transform childObj in childrenArray) {
            childObj.transform.gameObject.GetComponent<MeshRenderer>().material = previousParentMatList[objectToRemoveIndex];
            childObj.transform.gameObject.tag = "Reverse Lens";
        }

    }

    // Carries out the logic behind saving an objects (that doesn't have a parent) previous material + assigning it as reversible + changing its colour to the reverse one
    private void ReverseTagObjectLogic() {
        // Changes the tag to the Reverse Object tag - allows the object to be reversed
        hit.transform.gameObject.tag = "Reverse Object";
        // Saves the Objects Material in an array so it can revert back to its material once it is un-tagged
        previousParentMatList.Add(hit.transform.gameObject.GetComponent<MeshRenderer>().material);
        // Changes Color of Object Material to Reversible Material
        hit.transform.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;
    }

    // Carries out the logic behind saving a parent objects (the child has been tagged) previous material + assigning it as reversible + changing its colour to the reverse one
    private void ReverseTagParentLogic() {
        // Changes both the Child the Parents tag to the Reverse Object tag - allows the objects to be reversed
        hit.transform.gameObject.tag = "Reverse Object";
        hit.transform.parent.gameObject.tag = "Reverse Object";

        // Saves the Objects Material in an array so it can revert back to its material once it is un-tagged
        previousParentMatList.Add(hit.transform.parent.gameObject.GetComponent<MeshRenderer>().material);
		// Changes Color of Object Material to Reversible Material
		hit.transform.parent.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;
        ChangeParentChildrensMaterial();
    }

    // Checks if the Object hit with the ray is reversible or not.
    private void TagObject() {
        CheckParent();
    }
}