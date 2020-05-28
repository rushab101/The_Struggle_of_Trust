using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{


     public static GameObject t;
 
     private void Awake()
     {
         if (t != gameObject || !t)
             t = gameObject;
     }
 
     public void _StartCoroutine(IEnumerator iEnumerator)
     {            
         StartCoroutine(iEnumerator);
     }
     public void _StartCoroutine()
     {
        DeadState  t = new  DeadState();
         StartCoroutine(t.enumerator());
     }
}
