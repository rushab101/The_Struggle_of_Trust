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
    //    PlayerPrefs.DeleteAll();
        SceneLoader = PlayerPrefs.GetInt("Scene");
        Debug.Log(SceneLoader);
        if (SceneLoader == 0)
        {
            level = "CutScene";
            PlayerPrefs.SetFloat("Check1",1.1f);
        }
        else if (SceneLoader == 3)
        {
            level = "Beginning";
        }
          else if (SceneLoader == 4)
        {
            level = "CaveEntrance";
        }
        else if (SceneLoader == 6)
        {
            level = "MiddleCave";
             //PlayerPrefs.SetFloat("Check1",3.1f);
        }
        else if (SceneLoader == 7)
        {
            level = "BossFight1";
        }
        else if (SceneLoader == 8)
        {
            level = "CaveExit";
        }
      
    //    FindObjectOfType<Scene1Save>().ResetValues();
        
    }
    public void PlayGame()
    {
  
       //  FindObjectOfType<PlayerStats>().ResetHealth();
    //    FindObjectOfType<Scene1Save>().ResetValues();
    // level = "Beginning";
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

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
        level = "CutScene";
        PlayerPrefs.SetFloat("Check1",1.1f);
        PlayGame();

    }


}
