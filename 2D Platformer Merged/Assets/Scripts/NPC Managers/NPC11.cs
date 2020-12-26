using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC11 : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject gru;
    private bool firstSentence = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasObject.SetActive(false);
        gru.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int get_val = PlayerPrefs.GetInt("NPC_Gate");
        if (Input.GetKeyDown(KeyCode.E) && firstSentence == true)
        {
            if (get_val == 0)
            {
                FindObjectOfType<DialogueManagerNPC11>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC11>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC11>().sentences.Count == 0)
                {
                    canvasObject.SetActive(false);
                    FindObjectOfType<OpenGateScript>().EnterMenu();
                }
            }
            else if (get_val == 1)
            {
               FindObjectOfType<DialogueManagerNPC11_partb>().DisplayNextSentence();
                if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerNPC11_partb>().sentences.Count != 0)
                    FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerNPC11_partb>().sentences.Count == 0)
                {
                    canvasObject.SetActive(false);
                     FindObjectOfType<PauseMenu>().canPauseGame = true;
                }
            }
        }



    }



    private void OnTriggerStay2D(Collider2D collision)
    {
      int get_val = PlayerPrefs.GetInt("NPC_Gate");
        if (Input.GetKey(KeyCode.E) && !firstSentence && collision.CompareTag("Player"))
        {
            canvasObject.SetActive(true);
            firstSentence = true;
             FindObjectOfType<PauseMenu>().canPauseGame = false;
            if (get_val == 0)
            FindObjectOfType<DialogueTriggerNPC11>().TriggerDialogue();
            else if (get_val == 1)
            FindObjectOfType<DialogueTriggerNPC11_partb>().TriggerDialogue();
        }




    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasObject.SetActive(false);
        firstSentence = false;
         FindObjectOfType<PauseMenu>().canPauseGame = true;

    }
}
