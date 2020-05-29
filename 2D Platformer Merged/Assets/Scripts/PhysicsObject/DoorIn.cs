using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIn : MonoBehaviour
{
   
    private bool first = false;
    public GameObject door1;
    public GameObject door2;
    private Animator door;
    public GameObject canvasObject;

    // Start is called before the first frame update
    void Start()
    {
       // door1 = GameObject.Find("House Interior");
      //  door2 = GameObject.Find("ExteriorScene");
    
      door = GetComponent<Animator>();
      door.updateMode = AnimatorUpdateMode.UnscaledTime;
          FindObjectOfType<FSTDemoManager>().PanelAnim(6);
     //     FindObjectOfType<FSTDemoManager>().Restart();
     canvasObject.GetComponent<CanvasGroup>().alpha = 0f;
        // canvasObject.GetComponent<CanvasGroup>().alpha = 0f;
     //  canvasObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

        private void OnTriggerStay2D(Collider2D collision) 
    {
     
                     
          
       
        if (Input.GetKey(KeyCode.E) && !first)
        {
             canvasObject.GetComponent<CanvasGroup>().alpha = 1f;
            Debug.Log("Went into the house");

             first = true;
         FindObjectOfType<PlayerController>().canMove=false;
                FindObjectOfType<PlayerController>().canFlip=false;
            door.SetBool("open", true);
             canvasObject.SetActive(true);
           // FindObjectOfType<FSTDemoManager>().PanelAnim(6);
            
                StartCoroutine(Test());
                 Time.timeScale = 0.0f;
                FindObjectOfType<FSTDemoManager>().currentPanelAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                 FindObjectOfType<FSTDemoManager>().styleAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                 FindObjectOfType<FSTDemoManager>().nextPanelAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
           
                     FindObjectOfType<FSTDemoManager>().Restart();
                   
                 StartCoroutine(Test2());
              
    
        
              //  door1.SetActive(false);
             //   door2.SetActive(true);
                
   
        }
    }

    private void OnTriggerExit2D( Collider2D collision ) {
              FindObjectOfType<PlayerController>().canMove=true;
                FindObjectOfType<PlayerController>().canFlip=true;
                first = false;
                 
    }

     IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(0.3f);
        door.SetBool("open", false);
         door.SetBool("done", true);
    }

    
     IEnumerator Test2()
    {
        
        yield return new WaitForSecondsRealtime(1.0f);
      
        
             door1.SetActive(false);
                door2.SetActive(true);
                  Time.timeScale = 1f;
     
        
    
    }
}
