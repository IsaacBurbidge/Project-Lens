using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject mainMenuParent;
	[SerializeField]
	private GameObject levelSelectMenuParent;
	[SerializeField]
	private GameObject settingsMenuParent;

	// Main Menu Buttons:

	// Opens up the Level Select Menu
	public void LevelSelectButtonClicked() {
		levelSelectMenuParent.SetActive(true);
		mainMenuParent.SetActive(false);
	}
	// Opens up the Settings Menu
	public void SettingsButtonClicked() {
		settingsMenuParent.SetActive(true);
		mainMenuParent.SetActive(false);
	}
	// Quits the Game
	public void QuitButtonClicked() {
		Application.Quit();
	}

	// Level Select Menu Buttons:

	// Enters the Tutorial Level
	public void TutorialButtonClicked() {
		SceneManager.LoadScene("TeacherLevel");
	}
	public void LevelOneButtonClicked() {
		SceneManager.LoadScene("TrueLevel01");
	}
	public void LevelTwoButtonClicked() {
		SceneManager.LoadScene("TrueLevel02");
	}
	public void LevelThreeButtonClicked() {
		SceneManager.LoadScene("TrueLevel03");
	}

	// Returns to the Main Menu from the Level Select Menu
	public void LevelSelectBackButtonClicked() {
		levelSelectMenuParent.SetActive(false);
		mainMenuParent.SetActive(true);
	}

	// Returns to the Main Menu from the Settings Menu
	public void SettingsBackButtonClicked() {
		settingsMenuParent.SetActive(false);
		mainMenuParent.SetActive(true);
	}
}