using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Animator anim;
    public float timer = 0.45f;
    public bool noDamage = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Fall",true);
             StartCoroutine(Test());

        }


   
        
    }




        IEnumerator Test()
    {
        
        yield return new WaitForSeconds(timer);
      anim.SetBool("Fall",false);
      noDamage = true;
    }


}
