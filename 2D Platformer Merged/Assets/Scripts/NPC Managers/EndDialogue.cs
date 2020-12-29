using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDialogue : MonoBehaviour
{
       public GameObject canvasObject;
    public GameObject LoadingScreen;
    private bool firstSentence = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadingScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !firstSentence)
        {
            canvasObject.SetActive(true);
            firstSentence = true;
             FindObjectOfType<FinalCutSceneWorkingDialogue>().TriggerDialogue();

        }
        else if (firstSentence && Input.GetKeyDown(KeyCode.E)) 
        {
           
         //   if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerIntro>().sentences.Count != 1)
            FindObjectOfType<DialogueManagerEnd>().DisplayNextSentence();
           
            
                //FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerEnd>().sentences.Count == 1)
                {
                     //StartCoroutine(LoadYourAsyncScene());
                    //Debug.Log("It went into here");
                    canvasObject.SetActive(false);
                    LoadingScreen.SetActive(true);
                    // StartCoroutine(Test());
                    //FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
                   // SceneManager.LoadScene("Beginning");
                }
               
        }
        
    }

    
}
