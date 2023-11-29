using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    public string levelToLoad;

    public void OpenNewScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
