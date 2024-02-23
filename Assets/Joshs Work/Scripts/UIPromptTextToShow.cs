using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Attached to any trigger colliders that will show a UI Prompt text in World Space
// Type the desired UI Text in the inspector that you want to appear on screen when the player enters this objects trigger
public class UIPromptTextToShow : MonoBehaviour {
    public string uiPromptText = "";
	// Used for Prompts such as Lever Broken and then Fixed
	public bool canShowUIPrompt = false;

}