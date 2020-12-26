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
    int one_time_counter = 0;


    // private AudioSource audioSource;


    void Start()
    {
        //   PlayerPrefs.DeleteAll();
        pauseMenuUI.SetActive(false);
        controllMenuUI.SetActive(false);
        //        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
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
            if (one_time_counter== 0)
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
