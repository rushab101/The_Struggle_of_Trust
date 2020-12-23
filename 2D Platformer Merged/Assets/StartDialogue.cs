using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDialogue : MonoBehaviour
{
    public GameObject canvasObject;
    private bool firstSentence = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !firstSentence)
        {
            canvasObject.SetActive(true);
            firstSentence = true;
             FindObjectOfType<IntroCutSceneWorkingDialogue>().TriggerDialogue();

        }
        else if (firstSentence && Input.GetKeyDown(KeyCode.E)) 
        {
           

            FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
            if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerIntro>().sentences.Count != 0)
                //FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerIntro>().sentences.Count == 0)
                {
                 
                    canvasObject.SetActive(false);
                    SceneManager.LoadScene("Beginning");
                }
        }



    }



   
}
