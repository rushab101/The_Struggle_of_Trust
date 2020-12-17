using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string level;
    private int SceneLoader;

    void Awake()
    {
      //  PlayerPrefs.DeleteAll();
        SceneLoader = PlayerPrefs.GetInt("Scene");
        if (SceneLoader == 0)
        {
            level = "Beginning";
            PlayerPrefs.SetFloat("Check",3);
        }
        else if (SceneLoader == 1)
        {
            level = "Beginning";
        }
          else if (SceneLoader == 2)
        {
            level = "CaveEntrance";
        }
        else if (SceneLoader == 3)
        {
            level = "MiddleCave";
        }
        else if (SceneLoader == 4)
        {
            level = "CaveExit";
        }
      
    //    FindObjectOfType<Scene1Save>().ResetValues();
        
    }
    public void PlayGame()
    {
       //  FindObjectOfType<PlayerStats>().ResetHealth();
    //    FindObjectOfType<Scene1Save>().ResetValues();
        SceneManager.LoadScene(level);

    }
    private void Update() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
