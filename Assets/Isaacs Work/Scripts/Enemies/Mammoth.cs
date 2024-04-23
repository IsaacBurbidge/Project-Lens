using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammoth : MonoBehaviour{
    [SerializeField]
    Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        int rand = Random.Range(0, 2);
        animator.SetInteger("AnimSelected", rand);
    }
}
