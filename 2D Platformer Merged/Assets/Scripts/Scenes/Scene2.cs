using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{

    
    public GameObject canvasObject;


   void Start()
    {
       // door1 = GameObject.Find("House Interior");
      //  door2 = GameObject.Find("ExteriorScene");
    
    
           FindObjectOfType<FSTDemoManager>().PanelAnim(6);
    canvasObject.GetComponent<CanvasGroup>().alpha = 0f;
        
      

        
    }

      private void OnTriggerEnter2D(Collider2D collision) 
    {
         if (collision.CompareTag("Player"))
        {
         canvasObject.GetComponent<CanvasGroup>().alpha = 1f;
         PlayerPrefs.SetFloat("Check1", 2);
           Time.timeScale = 0.0f;
                FindObjectOfType<FSTDemoManager>().currentPanelAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                FindObjectOfType<FSTDemoManager>().styleAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                 FindObjectOfType<FSTDemoManager>().nextPanelAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
           
        FindObjectOfType<FSTDemoManager>().Restart();
         StartCoroutine(Test());
        }
       
    }
     IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(1.0f);
            SceneManager.LoadScene("CaveEntrance");
             Time.timeScale = 1f;
    
    }


}
