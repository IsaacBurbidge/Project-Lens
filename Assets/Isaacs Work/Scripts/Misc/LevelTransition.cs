using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {
	void LevelSwap(int LevelIndex) {
		SceneManager.LoadScene(LevelIndex);
	}

	void LevelSwap(string LevelName) {
		SceneManager.LoadScene(LevelName);
	}
}
