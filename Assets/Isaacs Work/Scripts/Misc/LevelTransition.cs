using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
	public void LevelSwap(int LevelIndex) {
		SceneManager.LoadScene(LevelIndex);
	}

	public void LevelSwap(string LevelName) {
		SceneManager.LoadScene(LevelName);
	}
}
