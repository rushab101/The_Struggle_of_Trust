using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC12 : MonoBehaviour
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
        int get_val = PlayerPrefs.GetInt("GainLife");;
       // UnityEngine.Debug.Log(get_val);
        if (Input.GetKeyDown(KeyCode.E) && firstSentence == true)
        {
            if (get_val < 2)
            {
                FindObjectOfType<DialogueManagerNPC12>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC12>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC12>().sentences.Count == 0)
                {
                    canvasObject.SetActive(false);
                    FindObjectOfType<NPCTALKGAINHEART>().EnterMenu();
                }
            }
            else if (get_val == 2)
            {
               FindObjectOfType<DialogueManagerNPC12_partb>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC12_partb>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC12_partb>().sentences.Count == 0)
                {
                    canvasObject.SetActive(false);
                     FindObjectOfType<PauseMenu>().canPauseGame = true;
                }
            }
        }



    }



    private void OnTriggerStay2D(Collider2D collision)
    {
      int get_val = PlayerPrefs.GetInt("GainLife");
        if (Input.GetKey(KeyCode.E) && !firstSentence && collision.CompareTag("Player"))
        {
            canvasObject.SetActive(true);
            firstSentence = true;
             FindObjectOfType<PauseMenu>().canPauseGame = false;
            if (get_val < 2)
            FindObjectOfType<DialogueTriggerNPC12>().TriggerDialogue();
            else if (get_val == 2)
            FindObjectOfType<DialogueTriggerNPC12_partb>().TriggerDialogue();
        }




    }


    private void OnTriggerExit2D(Collider2D collision)
    {
         FindObjectOfType<PauseMenu>().canPauseGame = true;
        canvasObject.SetActive(false);
        firstSentence = false;

    }
}
