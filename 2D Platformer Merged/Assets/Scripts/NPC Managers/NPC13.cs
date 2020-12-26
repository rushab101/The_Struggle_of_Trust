using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC13 : MonoBehaviour
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
        int get_val = PlayerPrefs.GetInt("NPC_Gate2");
       // Debug.Log(get_val);
        if (Input.GetKeyDown(KeyCode.E) && firstSentence == true)
        {
            
            if (get_val == 0)
            {
                FindObjectOfType<DialogueManagerNPC13>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC13>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC13>().sentences.Count == 0)
                {
                    canvasObject.SetActive(false);
                    FindObjectOfType<OpenCaveGate>().EnterMenu();
                }
            }
            else if (get_val == 1)
            {
               // Debug.Log("Its in here");
               FindObjectOfType<DialogueManagerNPC13_partb>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC13_partb>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC13_partb>().sentences.Count == 0)
                {
                     FindObjectOfType<PauseMenu>().canPauseGame = true;
                    canvasObject.SetActive(false);
                }
            }
        }



    }



    private void OnTriggerStay2D(Collider2D collision)
    {
      int get_val = PlayerPrefs.GetInt("NPC_Gate2");
        if (Input.GetKey(KeyCode.E) && !firstSentence && collision.CompareTag("Player"))
        {
            canvasObject.SetActive(true);
            firstSentence = true;
             FindObjectOfType<PauseMenu>().canPauseGame = false;
            if (get_val == 0)
            FindObjectOfType<DialogueTriggerNPC13>().TriggerDialogue();
            else if (get_val == 1)
            FindObjectOfType<DialogueTriggerNPC13_partb>().TriggerDialogue();
        }




    }


    private void OnTriggerExit2D(Collider2D collision)
    {
         FindObjectOfType<PauseMenu>().canPauseGame = true;
        canvasObject.SetActive(false);
        firstSentence = false;

    }
}
