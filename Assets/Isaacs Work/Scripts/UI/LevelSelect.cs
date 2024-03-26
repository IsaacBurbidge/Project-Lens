using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
	[SerializeField]
	GameObject MainMenu;

	public void OnBackClicked() {
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
