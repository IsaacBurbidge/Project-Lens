using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField]
	GameObject SettingsMenu;
	[SerializeField]
	GameObject LevelSelect;

	public void OnExitClicked() {
		Application.Quit();
	}
	public void OnSettingsClicked() {
		SettingsMenu.SetActive(true);
		gameObject.SetActive(false);
	}
	public void OnLevelSelectClicked() {
		LevelSelect.SetActive(true);
		gameObject.SetActive(false);
	}
}
