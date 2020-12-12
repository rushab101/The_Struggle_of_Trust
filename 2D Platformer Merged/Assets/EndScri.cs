using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScri : MonoBehaviour
{
      public void mainMenu()
    {
        //backgroundAudio.Play();
        SceneManager.LoadScene("Main Menu");
    }

   

    public void QuitGame()
    {
       
        Application.Quit();
    }
}
