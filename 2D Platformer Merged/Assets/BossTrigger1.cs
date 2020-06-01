using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger1 : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    public GameObject Lever;
    SpriteRenderer rend;
    public bool boss_is_dead = false;

       public GameObject canvasObject;
       public GameObject I;

       bool done_dialogue_sentence=false;



    bool went_in = false;

    void Start()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        E.SetActive(false);
        F.SetActive(false);
        G.SetActive(false);
        H.SetActive(false);
        I.SetActive(true);
        rend= Lever.GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a= 0f;
        rend.material.color =c;
        canvasObject.SetActive(false);

    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !went_in)
        {
           Time.timeScale = 0f;
           went_in = true;
             StartCoroutine(Test());
             StartCoroutine(Test2());
             StartCoroutine(Test3());
             StartCoroutine(Test4());
             StartCoroutine(Test5());
             StartCoroutine(Test6());
             StartCoroutine(Test7());
              StartCoroutine(Test8());

        }


   
        
    }

        IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
       A.SetActive(true);
    }

        IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(0.2f);
      B.SetActive(true);
    }

        IEnumerator Test3()
    {
        
        yield return new WaitForSecondsRealtime(0.3f);
       C.SetActive(true);
    }

        IEnumerator Test4()
    {
        
        yield return new WaitForSecondsRealtime(0.4f);
      D.SetActive(true);
    }

        IEnumerator Test5()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
     E.SetActive(true);
    }

        IEnumerator Test6()
    {
        
        yield return new WaitForSecondsRealtime(0.6f);
       F.SetActive(true);
    }
     IEnumerator Test7()
    {
        
        yield return new WaitForSecondsRealtime(0.7f);
       G.SetActive(true);
       Time.timeScale = 1f;
    }
       IEnumerator Test8()
    {
        
        yield return new WaitForSecondsRealtime(1.0f);

        canvasObject.SetActive(true);
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();

       
     
    }

      void Update()
    {
        if (!done_dialogue_sentence)
        {
            if (Input.GetKeyDown(KeyCode.E))
          {
             FindObjectOfType<DialogueManager>().DisplayNextSentence();
             if (FindObjectOfType<DialogueManager>().sentences.Count < 1)
             {
                 Debug.Log("Go to here");
                 done_dialogue_sentence = true;
                  canvasObject.SetActive(false);
                  I.SetActive(false);
                  H.SetActive(true); //Actual Boss Fight
             }
          }      
        }
        if (boss_is_dead)
        {
               StartCoroutine(Tes());
             StartCoroutine(Tes2());
             StartCoroutine(Tes3());
             StartCoroutine(Tes4());
             StartCoroutine(Tes5());
             StartCoroutine(Tes6());
             StartCoroutine(Tes7());
             StartCoroutine(FadeIn());
            boss_is_dead = false;

        }






        }

         IEnumerator Tes()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
       A.SetActive(false);
    }

        IEnumerator Tes2()
    {
        
        yield return new WaitForSecondsRealtime(0.2f);
      B.SetActive(false);
    }

        IEnumerator Tes3()
    {
        
        yield return new WaitForSecondsRealtime(0.3f);
       C.SetActive(false);
    }

        IEnumerator Tes4()
    {
        
        yield return new WaitForSecondsRealtime(0.4f);
      D.SetActive(false);
    }

        IEnumerator Tes5()
    {
        
        yield return new WaitForSecondsRealtime(0.5f);
     E.SetActive(false);
    }

        IEnumerator Tes6()
    {
        
        yield return new WaitForSecondsRealtime(0.6f);
       F.SetActive(false);
    }
     IEnumerator Tes7()
    {
        
        yield return new WaitForSecondsRealtime(0.7f);
       G.SetActive(false);
       //Time.timeScale = 1f;
    }

      IEnumerator FadeIn()
    {
        
       for (float f = 0.05f; f <=1; f+=0.05f)
       {
           Color c = rend.material.color;
           c.a = f;
           rend.material.color = c;
           yield return new WaitForSeconds(0.05f);
       }
    }


        
         


    
}
