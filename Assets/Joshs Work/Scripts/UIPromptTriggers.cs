using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPromptTriggers : MonoBehaviour {
    public List<GameObject> uiPromptTriggers;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // When Player Enters a trigger, it checks the objects prompt text and displays it in world space
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("UIPrompt")) {
            if (uiPromptTriggers.Contains(other.gameObject) == true && other.gameObject.GetComponent<UIPromptTextToShow>().canShowUIPrompt == true) {
                // Find the Object that you Triggered in a pre-defined list of UI Prompts and Display the relevant UI text in World Space
                int indexOfTrigger = uiPromptTriggers.IndexOf(other.gameObject);
                GameObject uiPromptTriggerGameObject = uiPromptTriggers[indexOfTrigger];
                // Sets the UI Prompt text to the pre-written UI Prompt text to be shown
                other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = other.gameObject.GetComponent<UIPromptTextToShow>().uiPromptText;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("UIPrompt")) {
            if (uiPromptTriggers.Contains(other.gameObject) == true && other.gameObject.GetComponent<UIPromptTextToShow>().canShowUIPrompt == true) {
                // Find the Object that you Triggered in a pre-defined list of UI Prompts and Display the relevant UI in World Space
                int indexOfTrigger = uiPromptTriggers.IndexOf(other.gameObject);
                GameObject uiPromptTriggerGameObject = uiPromptTriggers[indexOfTrigger];
                // Clears the UI Prompt text from World Space
                other.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = " ";
            }
        }
    }
}