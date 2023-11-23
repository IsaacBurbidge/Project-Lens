using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Perform Raycast at center of screen and check hit objects tag.
// If tag = Reverse Lens then swap to Reverse Object [Can now reverse]
// If tag = Reverse Object then swap to Reverse Lens [Cannot Reverse]
// Max 3 Objects can have Reverse Object tag in scene - Create a list and assign the object each time this tag is assigned
public class RaycastToObject : MonoBehaviour {
    // Add List variable to Lens.cs script - DO LATER! - OR - Could Add the Lens.cs script on creation of this script
    public List<GameObject> reversibleObjectsList;
    private RaycastHit hit;
    private int maxSizeOfList = 3;
    [SerializeField]
    private SwitchLens swapLensScript;

    [SerializeField]
    private Material defaultMat;
    [SerializeField]
    private Material reversibleMat;

    public void OnInteract() {
        if(StateManager.currentState == StateManager.PlayerStates.Gameplay) {
            ShootRayCast(hit);
        }
    }

    // Casts a Ray at the Mouses Position on Screen
    private void ShootRayCast(RaycastHit hit) {
        // Assigns the ray to the crosshair position on the screen [Center of screen]
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));
        // Checks if the ray has hit an object in the scene.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            // Displays a gizmo on screen of the ray (Only in the Scene Window)
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1f); // Ray gizmo remains on screen for 1 second inside the scene window
            CheckObjectsTag(hit);
        }
   
    }
    // Checks if the Object hit with the ray is reversible or not.
    private void CheckObjectsTag(RaycastHit hit) {
        // Checks if the reversibleObjectsList already contains the Object that the ray hit
        if (reversibleObjectsList.Contains(hit.transform.gameObject) == true) {
            // Removes Object from the List
            reversibleObjectsList.Remove(hit.transform.gameObject);
            // Reverts the tag back to the Reverse Lens default tag
            hit.transform.gameObject.tag = "Reverse Lens";
            // Changes Color of Object Material back to Default Material
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = defaultMat;
            

			if (GetComponent<SwitchLens>() != null && GetComponent<SwitchLens>().CurrentLens == Lens.LensList.REVERSE) {
				hit.transform.GetComponent<ReverseLens>().DeactivateLens();
            }

		} // Checks that the Object is not already inside the reversibleObjectsList and that it does contain the 'Reverse Lens' tag
        else if (reversibleObjectsList.Contains(hit.transform.gameObject) == false && hit.transform.CompareTag("Reverse Lens") == true) {
            // Check if the List has reached max capacity
            if (reversibleObjectsList.Count == maxSizeOfList) {
                // Display Error Message: Must remove an object from being reversible | Max is only 3
                Debug.Log("Max Objects that can be Reversible are 3. Please remove an object from being reversible");
            }
            // Check if the List hasn't reached max capacity
            else if (reversibleObjectsList.Count < maxSizeOfList) {
                // Adds Object to the List
                reversibleObjectsList.Add(hit.transform.gameObject);
                // Changes the tag to the Reverse Object tag - allows the object to be reversed
                hit.transform.gameObject.tag = "Reverse Object";
                // Changes Color of Object Material to Reversible Material
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = reversibleMat;


                if (GetComponent<SwitchLens>() != null && GetComponent<SwitchLens>().CurrentLens == Lens.LensList.REVERSE) {
                    hit.transform.GetComponent<ReverseLens>().ActivateLens();
                }

            }
        }
    }
}