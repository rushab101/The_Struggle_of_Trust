using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContineFire : MonoBehaviour
{
    // Start is called before the first frame update

    private GameMaster gm;
    bool first = false;
    float heal;
     public Canvas canvas;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
         canvas.transform.GetChild(0).gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    public void show_save_icon()
    {
        FindObjectOfType<Currency>().SaveSettings();
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        //  Debug.Log("Hi");
        //  anim.SetBool("setAttack", false);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.E) && !first)
        {
            //             Debug.Log("Went to here");
            //   first = true;
            gm.lastCheckPointPos = transform.position;
            FindObjectOfType<Currency>().SaveSettings();
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
            UnityEngine.Debug.Log(SceneManager.GetActiveScene().buildIndex);
           // UnityEngine.Debug.Log(SceneManager.GetActiveScene().buildIndex);
            heal = FindObjectOfType<PlayerStats>().MaxHealth;
            FindObjectOfType<PlayerStats>().Heal(heal);
            show_save_icon();
            SavePlayer(gm.lastCheckPointPos.x, gm.lastCheckPointPos.y);
            if (PlayerPrefs.GetInt("Scene") == 1)
            {
                FindObjectOfType<Scene0SaveScript>().SaveValues();
            }
            if (PlayerPrefs.GetInt("Scene") == 2)
            {
                FindObjectOfType<Scene1Save>().SaveValues();
            }
            



        }
    }



    public void SavePlayer(float x, float y)
    {
        SaveSystem.SavePlayer(x, y);
    }






    private void OnTriggerExit2D(Collider2D collision)
    {
        first = false;
    }
}
