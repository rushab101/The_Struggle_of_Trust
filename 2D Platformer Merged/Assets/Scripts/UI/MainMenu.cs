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
        
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene(level);
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


}
