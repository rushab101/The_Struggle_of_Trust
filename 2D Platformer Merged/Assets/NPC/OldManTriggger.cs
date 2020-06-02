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
    // Start is called before the first frame update
  
    void Start()
    {
        
              
            old_man_dia.SetActive(false);

         

    }

    // Update is called once per frame
    void Update()
    {
       
       
       

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !firstSentenceDone && !anim.GetBool("cancel"))
        {
            firstSentenceDone = true;
            old_man_dia.SetActive(true);
 old_man_dia.GetComponent<CanvasGroup>().alpha = 1f;;
            FindObjectOfType<DialogueTrigger2>().TriggerDialogue();
        }

    }

       private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && anim.GetBool("cancel"))
          {
             
              Time.timeScale = 0f;
 old_man_dia.GetComponent<CanvasGroup>().alpha = 1f;;
               old_man_dia.SetActive(true);
             FindObjectOfType<DialogueManager2>().DisplayNextSentence();
             if (FindObjectOfType<DialogueManager2>().sentences.Count == 0)
             {
               //  Debug.Log("In here");
                  Time.timeScale = 1f;
                //  old_man_dia.SetActive(false);
             }
          }
       

    }

 



    private void OnTriggerExit2D(Collider2D collision)
    {

        old_man_dia.SetActive(false);
        firstSentenceDone = false;
        this_plays_first = false;
    }






}
