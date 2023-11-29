using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderButton : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] LevelSelector levelSelector;
    public void levelClick()
    {
        levelSelector.levelToLoad = levelName;
        levelSelector.OpenNewScene();
    }    

}
