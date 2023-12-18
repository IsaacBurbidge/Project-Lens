using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI uiPromptText;

    private void Start()
    {
        uiPanel.SetActive(false);
        mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * 
            Vector3.up);
    }

    public bool IsDisplayed = false;
    public void Setup(string promptText)
    {
        uiPromptText.text = promptText;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        
        uiPanel.SetActive(false);
        IsDisplayed = false;

    }
}
