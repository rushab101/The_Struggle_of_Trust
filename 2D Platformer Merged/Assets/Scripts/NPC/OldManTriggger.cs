using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManTriggger : MonoBehaviour
{
    public GameObject old_man_dia;
    private bool firstSentenceDone = false;
     public Animator anim;

    public bool new_dia = false;
    private bool this_plays_first = false;
    public bool checker = false;
    // Start is called before the first frame update
  
    void Start()
    {
        
        //   PlayerPrefs.DeleteAll();   
            old_man_dia.SetActive(false);

         

    }

  void Update()
    {
       
       
          if (Input.GetKeyDown(KeyCode.E) && anim.GetBool("cancel") && this_plays_first)
          {
               old_man_dia.SetActive(true);
             FindObjectOfType<DialogueManager2>().DisplayNextSentence(); 
             if (old_man_dia.active && FindObjectOfType<DialogueManager2>().sentences.Count != 0) 
              FindObjectOfType<AudioManager>().Play("Render_Text_long"); // 06 June 2020          
             if (FindObjectOfType<DialogueManager2>().sentences.Count == 0)
             {
                 old_man_dia.SetActive(false);
             }
          }
       

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !firstSentenceDone && !anim.GetBool("cancel"))
        {
            firstSentenceDone = true;
            old_man_dia.SetActive(true);

            FindObjectOfType<DialogueTrigger2>().TriggerDialogue();
            FindObjectOfType<AudioManager>().Play("Render_Text_long"); // 06 June 2020
        }
        if (anim.GetBool("cancel"))
        {
            FindObjectOfType<DialogueTrigger2>().TriggerDialogue();
        }

    }

    
       private void OnTriggerStay2D(Collider2D collision)
    {
        this_plays_first = true;
       

    }
   
 



    private void OnTriggerExit2D(Collider2D collision)
    {
         FindObjectOfType<AudioManager>().Pause("Render_Text_long"); // 06 June 2020
        old_man_dia.SetActive(false);
        firstSentenceDone = false;
        this_plays_first = false;
    }






}
