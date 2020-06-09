using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInSection1 : MonoBehaviour
{
    public bool went_in = false;
    public GameObject canvasObject;
    public Text myPanel;
    private CanvasGroup canvas;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!went_in)
        {
            went_in = true;
            StartCoroutine(FadeIn());

        }


    }

    IEnumerator FadeIn()
    {
        // start fading
        yield return StartCoroutine(FadeEffect.FadeCanvas(canvas, 0f, 1f, 2f));
        StartCoroutine(FadeOut());
        // code here will run once the fading coroutine has completed

    }

    IEnumerator FadeOut()
    {
        // start fading
        yield return StartCoroutine(FadeEffect.FadeCanvas(canvas, 1f, 0f, 1.2f));
        // code here will run once the fading coroutine has completed

    }




    // Start is called before the first frame update
    void Start()
    {
        canvas = canvasObject.GetComponent<CanvasGroup>();
        StartCoroutine(FadeEffect.FadeCanvas(canvas, 0f, 0f, 0f));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
