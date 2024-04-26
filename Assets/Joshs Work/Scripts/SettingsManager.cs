using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
	// An array of all audio sources that need to be added by hand
	[SerializeField]
	private AudioSource[] allAudioClipArray;
	[SerializeField]
	private Slider volumeSlider;
	[SerializeField]
	private TextMeshProUGUI volumeValueText;

	void Start() {
		// Add all Audio Sources from the Scene to an Array
		allAudioClipArray = FindObjectsOfType<AudioSource>();

		// Checks to see if Volume has not been previously saved in Player Preferences
		// If true, then a default value is set to 0.50
		// If false, then it will retrieve the most recent value in Player preferences
		if (!PlayerPrefs.HasKey("Volume")) {
			// Sets the deafault Volume to 50% if there is no previously saved volume data.
			PlayerPrefs.SetFloat("Volume", 0.50f);
			volumeSlider.value = 0.50f;
			SetVolume();
		}
		else {
			GetVolume();
		}
	}

	// Volume Functions:
	// This function will load the Volume from Players preferences.
	public void GetVolume() {
		volumeSlider.value = PlayerPrefs.GetFloat("Volume");
		SetVolume();
	}
	// This function will save the Volume in Players preferences.
	public void SetVolume() {
		PlayerPrefs.SetFloat("Volume", volumeSlider.value);
		volumeValueText.text = ((int)(volumeSlider.value * 10)).ToString();
		UpdateVolume(volumeSlider.value);
	}
	// This function will save the Volume slider's value to the Player preferences once it has been changed in run-time.
	public void ChangeVolume() {
		// The Volume of the game will be equal to the slider value.
		AudioListener.volume = volumeSlider.value;
		SetVolume();
		UpdateVolume(volumeSlider.value);
	}
	public void UpdateVolume(float volume) {
		foreach (AudioSource audioClip in allAudioClipArray) {
			audioClip.volume = volume;
		}
	}

	// Lens Tint Functions:
	// Slider 1 - 3 
	// Low Medium High
	
}