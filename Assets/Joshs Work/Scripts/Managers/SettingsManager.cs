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
	[SerializeField]
	private TMP_Dropdown lensTintIntensityDropdown;
	[SerializeField]
	private Image lensTintImage;

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

		// Checks to see if Tint Intensity has not been previously saved in Player Preferences
		// If true, then a default value is set to 0.35
		// If false, then it will retrieve the most recent value in Player preferences
		if (!PlayerPrefs.HasKey("LensTintIntensity")) {
			// Sets the default Tint Intensity to 35% if there is no previously saved volume data.
			PlayerPrefs.SetFloat("LensTintIntensity", 0.35f);
			lensTintIntensityDropdown.value = (int)0.35f;
			SetTintIntensity();
		}
		else {
			GetTintIntensity();
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
	// This function will load the Lens Tint Intensity from Players preferences.
	public void GetTintIntensity() {
		lensTintIntensityDropdown.value = (int)PlayerPrefs.GetFloat("LensTintIntensity");
		SetVolume();
	}
	// This function will save the Lens Tint Intensity in Players preferences.
	public void SetTintIntensity() {
		PlayerPrefs.SetFloat("LensTintIntensity", lensTintIntensityDropdown.value);
		UpdateTintIntensity(lensTintIntensityDropdown.value);
	}
	// This function will save the Lens Tint Intensity dropdown value to the Player preferences once it has been changed in run-time.
	public void ChangeTintIntensity() {
		SetTintIntensity();
		UpdateTintIntensity(lensTintIntensityDropdown.value);
	}
	public void UpdateTintIntensity(float intensity) {
		Color lensTintColour = lensTintImage.color;
		switch (intensity) {
			case 0:
				// Low Intensity
				lensTintColour.a = 0.25f;
				lensTintImage.color = lensTintColour;
				break;
			case 1:
				// Medium Intensity
				lensTintColour.a = 0.35f;
				lensTintImage.color = lensTintColour;
				break;
			case 2:
				// High Intensity
				lensTintColour.a = 0.45f;
				lensTintImage.color = lensTintColour;
				break;
		}
	}
}