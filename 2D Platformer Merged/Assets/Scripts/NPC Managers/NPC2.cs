﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
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
        
         if (Input.GetKeyDown(KeyCode.E) && firstSentence)
          {
             FindObjectOfType<DialogueManagerNPC3>().DisplayNextSentence();
            if (canvasObject.activeSelf)
            FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020

             if (FindObjectOfType<DialogueManagerNPC3>().sentences.Count == 0)
             {
                FindObjectOfType<PauseMenu>().canPauseGame = true;
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

        if (Input.GetKey(KeyCode.E) && !firstSentence)
        {
          // Debug.Log("In TRIGGER ZONE");
                canvasObject.SetActive(true);
                 firstSentence = true;
                 FindObjectOfType<Currency>().SaveSettings();
                FindObjectOfType<DialogueTriggerNPC3>().TriggerDialogue();
                PlayerPrefs.SetInt("Code_B",1);
               FindObjectOfType<PauseMenu>().canPauseGame = false;
                 
        }

      

      
    }


     private void OnTriggerExit2D( Collider2D collision ) {
       canvasObject.SetActive(false);
       firstSentence = false;
        FindObjectOfType<PauseMenu>().canPauseGame = true;         
    }


}
