using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard_Anim : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.GetComponentInChildren<Dartboard>().isSolved) anim.SetTrigger("isComplete");
    }
}
