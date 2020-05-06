using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        startUI.SetActive(true);
        Time.timeScale = 0f;


    }

    public void Continue()
    {
        startUI.SetActive(false);
        Time.timeScale = 1f;

    }

    
}
