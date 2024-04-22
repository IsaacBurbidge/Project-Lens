using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField]
	GameObject PauseMenuObject;

	public void OnPause() {
		Time.timeScale = 0f;
		PauseMenuObject.SetActive(true);
	}

	public void OnResume() {
		Time.timeScale = 1.0f;
		PauseMenuObject.SetActive(false);
	}

	public void ReturnToMenu() {
		SceneManager.LoadScene(0);
	}
}
