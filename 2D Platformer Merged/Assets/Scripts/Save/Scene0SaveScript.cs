using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene0SaveScript : MonoBehaviour
{

    public GameObject Create1;
    public GameObject Create2;
    private GameObject Create1_child;
    private GameObject Create2_child;
    // Start is called before the first frame update
    void Start()
    {
        Create1_child = Create1.transform.GetChild(0).gameObject;
        Create2_child = Create2.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Create1_child.activeSelf)
        {
         
            if (PlayerPrefs.GetInt("Create1_scene1") == 0)
            {
                PlayerPrefs.SetInt("Create1_scene1", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create1_scene1") == 1 || PlayerPrefs.GetInt("Create1_scene1") == 2)
        {
             
            Create1_child.SetActive(false);
        }
        //Create 2
        if (!Create2_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create2_scene1") == 0)
            {
                PlayerPrefs.SetInt("Create2_scene1", 1);
                // RedWall.SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("Create2_scene1") == 1 || PlayerPrefs.GetInt("Create2_scene1") == 2)
        {
           
            Create2_child.SetActive(false);
        }

        if (FindObjectOfType<PlayerStats>().GameOver)
        {
            ResetValues();
        }

    }


    public void OnApplicationQuit()
    {
        if (PlayerPrefs.GetInt("Create1_scene1") == 1)
        {
            PlayerPrefs.SetInt("Create1_scene1", 0);
            Create1_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create2_scene1") == 1)
        {
            PlayerPrefs.SetInt("Create2_scene1", 0);
            Create2_child.SetActive(true);
        }

    }

    public void ResetValues()
    {
        if (PlayerPrefs.GetInt("Create1_scene1") == 1)
        {
            PlayerPrefs.SetInt("Create1_scene1", 0);
            Create1_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create2_scene1") == 1)
        {
            PlayerPrefs.SetInt("Create2_scene1", 0);
            Create2_child.SetActive(true);
        }
    }

    public void SaveValues()
    {
        if (PlayerPrefs.GetInt("Create1_scene1") == 1)
        {
              Debug.Log("In Create 2");
            PlayerPrefs.SetInt("Create1_scene1", 2);
        }
        //Create 2

        if (PlayerPrefs.GetInt("Create2_scene1") == 1)
        {
                Debug.Log("In Create 1");
            PlayerPrefs.SetInt("Create2_scene1", 2);
        }

    }
}
