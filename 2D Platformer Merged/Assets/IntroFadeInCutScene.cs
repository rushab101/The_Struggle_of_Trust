using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroFadeInCutScene : MonoBehaviour
{
   
    public bool went_in = false;
    public GameObject canvasObject;
    public Text myPanel;
    private CanvasGroup canvas;





  
    IEnumerator FadeIn()
    {

        // start fading
        yield return StartCoroutine(FadeEffect.FadeCanvas(canvas, 0f, 1f, 3f));
        StartCoroutine(FadeOut());
        // code here will run once the fading coroutine has completed

    }

    IEnumerator FadeOut()
    {
        // start fading
        yield return StartCoroutine(FadeEffect.FadeCanvas(canvas, 1f, 0f, 3.0f));
        // code here will run once the fading coroutine has completed
        SceneManager.LoadScene("Main Menu");

    }




    // Start is called before the first frame update
    void Start()
    {
        canvasObject.SetActive(false);
        canvas = canvasObject.GetComponent<CanvasGroup>();
        StartCoroutine(FadeEffect.FadeCanvas(canvas, 0f, 0f, 0f));
         StartCoroutine(Test());
        
    }
     IEnumerator Test()
    {

        yield return new WaitForSeconds(1.0f);
        canvasObject.SetActive(true);
        StartCoroutine(FadeIn());
       
    }



    
}