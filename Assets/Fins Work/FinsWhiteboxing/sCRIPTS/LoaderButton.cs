using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderButton : MonoBehaviour
{
    [Header("Level Loading")]
    [SerializeField] string levelName;
    [SerializeField] LevelSelector levelSelector;
    [Header("Animation")]
    [SerializeField] Animator levelAnimator;
    [SerializeField] public float transitionTime = 1f;
    [SerializeField] string animatorParamName;
    [SerializeField] bool hasLevelTransition;


    public void levelClick()
    {     
      StartCoroutine(LoadLevel(levelName));  
    }

    IEnumerator LoadLevel(string levelName)
    {
        if (hasLevelTransition)
        {
            levelAnimator.SetTrigger("Triggered");
            yield return new WaitForSeconds(transitionTime);
        }
        levelSelector.levelToLoad = levelName;
        levelSelector.OpenNewScene();
    }
}
