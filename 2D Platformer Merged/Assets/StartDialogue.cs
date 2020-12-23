using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDialogue : MonoBehaviour
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
             FindObjectOfType<IntroCutSceneWorkingDialogue>().TriggerDialogue();

        }
        else if (firstSentence && Input.GetKeyDown(KeyCode.E)) 
        {
           
         //   if (canvasObject.activeSelf && FindObjectOfType<DialogueManagerIntro>().sentences.Count != 1)
            FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
           
            
                //FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerIntro>().sentences.Count == 1)
                {
                     //StartCoroutine(LoadYourAsyncScene());
                    //Debug.Log("It went into here");
                    canvasObject.SetActive(false);
                    LoadingScreen.SetActive(true);
                     StartCoroutine(Test());
                    //FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
                   // SceneManager.LoadScene("Beginning");
                }
               
        }
         //FindObjectOfType<AudioManager>().Play("Render_Text"); // 06 June 2020
                if (FindObjectOfType<DialogueManagerIntro>().sentences.Count == 0 && firstSentence)
                {
                   
                    SceneManager.LoadScene("Beginning");
                }
    }

      IEnumerator Test()
    {

        yield return new WaitForSecondsRealtime(0.1f);
        FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
       // FindObjectOfType<DialogueManagerIntro>().DisplayNextSentence();
        
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Beginning");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }



   
}
