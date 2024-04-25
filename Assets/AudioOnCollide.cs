using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollide : MonoBehaviour
{
    AudioSource soundSource;
    [SerializeField] string playerTag;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (soundSource != null && !collision.gameObject.CompareTag(playerTag))
        {
            soundSource.Play();
        }
    }
}
