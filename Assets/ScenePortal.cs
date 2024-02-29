using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenePortal : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private int sceneIndexNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            SceneManager.LoadScene(sceneIndexNumber);
        }    
    }

}
