using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManTriggger : MonoBehaviour
{
    public GameObject old_man_dia;
    private bool firstSentenceDone = false;
     public Animator anim;

    public bool new_dia = false;
    // Start is called before the first frame update
    void Start()
    {
        old_man_dia.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
          if (Input.GetKeyDown(KeyCode.E) && anim.GetBool("cancel"))
          {
               old_man_dia.SetActive(true);
             FindObjectOfType<DialogueManager2>().DisplayNextSentence();
             if (FindObjectOfType<DialogueManager2>().sentences.Count < 1)
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
        }

    }

 



    private void OnTriggerExit2D(Collider2D collision)
    {

        old_man_dia.SetActive(false);
        firstSentenceDone = false;
    }






}
