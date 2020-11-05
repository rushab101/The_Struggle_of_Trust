﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Animator animator;
    public GameObject a;
    bool gate_open = false;




    // Start is called before the first frame update
    void Start()
    {
       // a.SetActive(false);
        animator.SetBool("close", false);
        animator.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Lever>().open_portal)
        {
           ;
            gate_open = true;
            animator.SetBool("close", true);
            StartCoroutine(Test2());
        }
    }


         IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
            
            animator.SetBool("open", true);
            animator.SetBool("close", false);
     
    }



}