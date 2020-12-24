using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal4 : MonoBehaviour
{
     public Animator animator;
    public GameObject a;
    public bool gate_open = false;




    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("In portal");
       // a.SetActive(false);
        animator.SetBool("close", false);
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(FindObjectOfType<Lever>().open_portal);
        if (FindObjectOfType<Lever4>().open_portal)
        {
           Debug.Log("In portal");
            gate_open = true;
            animator.SetBool("close", true);
            StartCoroutine(Test2());
        }
    }


         IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
            animator.SetBool("close", false);
     
    }
}
