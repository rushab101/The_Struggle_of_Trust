using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool canPauseGame = true;
    public GameObject pauseMenuUI;
    public GameObject controllMenuUI;

    public GameObject code1;
    public GameObject code2;
    public GameObject code3;
    public GameObject code4;
    public GameObject code5;
    public GameObject code6;
    public GameObject code7;
    public GameObject code8;
    public GameObject code9;



    int one_time_counter = 0;


    // private AudioSource audioSource;
    int Code_A= 0;
    int Code_B= 0;
    int Code_C= 0;
    int Code_D= 0;
    int Code_E= 0;
    int Code_F= 0;
    int Code_G= 0;
    int Code_H= 0;
    int Code_I= 0;

    private void Awake() {
        Code_A = PlayerPrefs.GetInt("Code_A");
        Code_B = PlayerPrefs.GetInt("Code_B");
        Code_C = PlayerPrefs.GetInt("Code_C");
        Code_D = PlayerPrefs.GetInt("Code_D");
        Code_E = PlayerPrefs.GetInt("Code_E");
        Code_F = PlayerPrefs.GetInt("Code_F");
        Code_G = PlayerPrefs.GetInt("Code_G");
        Code_H = PlayerPrefs.GetInt("Code_H");
        Code_I = PlayerPrefs.GetInt("Code_I");
    }

    void Start()
    {
        //   PlayerPrefs.DeleteAll();
        pauseMenuUI.SetActive(false);
        controllMenuUI.SetActive(false);
        if (Code_A == 1)
        {
            code1.SetActive(true);
        } else{
            code1.SetActive(false);
        }
         if (Code_B == 1)
        {
            code2.SetActive(true);
        } else{
            code2.SetActive(false);
        }
         if (Code_C == 1)
        {
            code3.SetActive(true);
        } else{
            code3.SetActive(false);
        }
         if (Code_D == 1)
        {
            code4.SetActive(true);
        } else{
            code4.SetActive(false);
        }
         if (Code_E == 1)
        {
            code5.SetActive(true);
        } else{
            code5.SetActive(false);
        }
         if (Code_F == 1)
        {
            code6.SetActive(true);
        } else{
            code6.SetActive(false);
        }
         if (Code_G == 1)
        {
            code7.SetActive(true);
        } else{
            code7.SetActive(false);
        }
         if (Code_H == 1)
        {
            code8.SetActive(true);
        } else{
            code8.SetActive(false);
        }
         if (Code_I == 1)
        {
            code9.SetActive(true);
        } else{
            code9.SetActive(false);
        }


    }



    // Update is called once per frame
    void Update()
    {
         Code_A = PlayerPrefs.GetInt("Code_A");
        Code_B = PlayerPrefs.GetInt("Code_B");
        Code_C = PlayerPrefs.GetInt("Code_C");
        Code_D = PlayerPrefs.GetInt("Code_D");
        Code_E = PlayerPrefs.GetInt("Code_E");
        Code_F = PlayerPrefs.GetInt("Code_F");
        Code_G = PlayerPrefs.GetInt("Code_G");
        Code_H = PlayerPrefs.GetInt("Code_H");
        Code_I = PlayerPrefs.GetInt("Code_I");
        
         if (Code_A == 1)
        {
            code1.SetActive(true);
        } else{
            code1.SetActive(false);
        }
         if (Code_B == 1)
        {
            code2.SetActive(true);
        } else{
            code2.SetActive(false);
        }
         if (Code_C == 1)
        {
            code3.SetActive(true);
        } else{
            code3.SetActive(false);
        }
         if (Code_D == 1)
        {
            code4.SetActive(true);
        } else{
            code4.SetActive(false);
        }
         if (Code_E == 1)
        {
            code5.SetActive(true);
        } else{
            code5.SetActive(false);
        }
         if (Code_F == 1)
        {
            code6.SetActive(true);
        } else{
            code6.SetActive(false);
        }
         if (Code_G == 1)
        {
            code7.SetActive(true);
        } else{
            code7.SetActive(false);
        }
         if (Code_H == 1)
        {
            code8.SetActive(true);
        } else{
            code8.SetActive(false);
        }
         if (Code_I == 1)
        {
            code9.SetActive(true);
        } else{
            code9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !GameIsPaused)
        {

            if (GameIsPaused)
            {
                Resume();

            }
            else if (canPauseGame)
            {
                Pause();
            }
        }
        if (!GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (one_time_counter == 0)
            {
                //FindObjectOfType<AudioManager>().PlayAllSFXSounds();
                one_time_counter++;
            }

        }
        else if (GameIsPaused)
        {
            one_time_counter = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FindObjectOfType<AudioManager>().PauseAllSFXSounds();
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        // audioSource.Play();
        GameIsPaused = false;

    }

    public void Pause()
    {
        controllMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        // audioSource.Pause();
        GameIsPaused = true;
    }

    public void mainMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //backgroundAudio.Play();
        FindObjectOfType<PlayerStats>().ResetHealth();
        SceneManager.LoadScene("Main Menu");
    }

    public void ControllerMenu()
    {

        pauseMenuUI.SetActive(false);
        controllMenuUI.SetActive(true);

    }

    public void QuitGame()
    {
        FindObjectOfType<PlayerStats>().ResetHealth();
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
