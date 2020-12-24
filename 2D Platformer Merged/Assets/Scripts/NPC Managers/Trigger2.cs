using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
   public Animator anim;
    public bool noDamage = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("first",true);
             StartCoroutine(Test());

        }


   
        
    }




        IEnumerator Test()
    {
        
        yield return new WaitForSeconds(0.35f);
      anim.SetBool("first",false);
      noDamage = true;
    }
}
