using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class EndTrigger : MonoBehaviour
{
     public GameObject enter_code_menu;
     private InputField input;

    // Start is called before the first frame update
    void Start()
    {
        input = enter_code_menu.GetComponent<InputField>();
       

        enter_code_menu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerStay2D(Collider2D collision) {
       
        if (Input.GetKeyDown(KeyCode.N))
        {
            EnterMenu();
        }

    }



    void EnterMenu()
    {
        enter_code_menu.SetActive(true);
         Time.timeScale = 0f;
        input.onEndEdit.AddListener(delegate { inputBetValue(input); });



    }

      public  void Resume()
    {
        enter_code_menu.SetActive(false);
        Time.timeScale = 1f;
    }

public void inputBetValue(InputField userInput)
{
    
    Debug.Log(userInput.text);
}

}
