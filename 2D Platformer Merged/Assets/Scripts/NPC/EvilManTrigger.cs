using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilManTrigger : MonoBehaviour
{
        public GameObject old_man_dia;
    private bool firstSentenceDone = false;
     public Animator anim;

    public bool new_dia = false;
      private bool this_plays_first = false;
    // Start is called before the first frame update
    void Start()
    {
        old_man_dia.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
          if (Input.GetKeyDown(KeyCode.E) && anim.GetBool("cancel") && this_plays_first)
          {
               old_man_dia.SetActive(true);
             FindObjectOfType<DialogueManager3>().DisplayNextSentence();
              FindObjectOfType<AudioManager>().Play("Render_Text_long"); // 06 June 2020   
              StartCoroutine(Test());
             StartCoroutine(Test2());
             StartCoroutine(Test3());
             StartCoroutine(Test4());
             StartCoroutine(Test5());
             StartCoroutine(Test6());
             StartCoroutine(Test7());
            
             if (FindObjectOfType<DialogueManager3>().sentences.Count < 1)
             {
                 FindObjectOfType<PauseMenu>().canPauseGame = true;
                //  old_man_dia.SetActive(false);
             }
          }
       

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !firstSentenceDone && !anim.GetBool("cancel"))
        {
            firstSentenceDone = true;
            old_man_dia.SetActive(true);
            FindObjectOfType<PauseMenu>().canPauseGame = false;
            FindObjectOfType<DialogueTrigger3>().TriggerDialogue();
            FindObjectOfType<AudioManager>().Play("Render_Text_long"); // 06 June 2020
        }

    }

    
       private void OnTriggerStay2D(Collider2D collision)
    {
        this_plays_first = true;
       

    }


 



    private void OnTriggerExit2D(Collider2D collision)
    {

        old_man_dia.SetActive(false);
        FindObjectOfType<AudioManager>().Pause("Render_Text_long"); // 06 June 2020
        firstSentenceDone = false;
        FindObjectOfType<PauseMenu>().canPauseGame = true;
          this_plays_first = false;
    }

     IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(1.0f);
     FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }

        IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(2.0f);
    FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }

        IEnumerator Test3()
    {
        
        yield return new WaitForSecondsRealtime(3.0f);
   FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }

        IEnumerator Test4()
    {
        
        yield return new WaitForSecondsRealtime(4.0f);
  FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }

        IEnumerator Test5()
    {
        
        yield return new WaitForSecondsRealtime(5.0f);
    FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }

        IEnumerator Test6()
    {
        
        yield return new WaitForSecondsRealtime(6.0f);
    FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
     IEnumerator Test7()
    {
        
        yield return new WaitForSecondsRealtime(7.0f);
     FindObjectOfType<PlayerStats>().TakeDamage(1f);
    }
    
}
