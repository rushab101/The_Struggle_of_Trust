using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FadeEffect : MonoBehaviour {
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
    {
         // keep track of when the fading started, when it should finish, and how long it has been running&lt;/p&gt; &lt;p&gt;&a
         var startTime = Time.time;
         var endTime = Time.time + duration;
         var elapsedTime = 0f;
 
         // set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
         canvas.alpha = startAlpha;
         // loop repeatedly until the previously calculated end time
         while (Time.time <= endTime)
         {
             elapsedTime = Time.time - startTime; // update the elapsed time
             var percentage = 1/(duration/elapsedTime); // calculate how far along the timeline we are
             if (startAlpha > endAlpha) // if we are fading out/down 
             {
                  canvas.alpha = startAlpha - percentage; // calculate the new alpha
             }
             else // if we are fading in/up
             {
                 canvas.alpha = startAlpha + percentage; // calculate the new alpha
             }
 
             yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
        }
        canvas.alpha = endAlpha; // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
}
}