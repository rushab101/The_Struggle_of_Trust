using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OldLadyTrigger : MonoBehaviour
{
    public GameObject canvasObject;
    private bool firstSentence = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetKeyDown(KeyCode.UpArrow))
          {
             FindObjectOfType<DialogueManager>().DisplayNextSentence();
             if (FindObjectOfType<DialogueManager>().sentences.Count < 0)
             {
                  canvasObject.SetActive(false);
             }
          }

         
              
    }

  private void OnTriggerEnter2D(Collider2D collision) 
    {
      /*
         if (collision.CompareTag("Player"))
        {
                canvasObject.SetActive(true);
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                 
        }
  */
    }

  
       private void OnTriggerStay2D(Collider2D collision) 
    {

        if (Input.GetKey(KeyCode.UpArrow) && !firstSentence)
        {
                canvasObject.SetActive(true);
                 firstSentence = true;
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
               
                 
        }

      

      
    }


     private void OnTriggerExit2D( Collider2D collision ) {
       canvasObject.SetActive(false);
       firstSentence = false;
                 
    }



}
