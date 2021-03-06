﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirePlaceCheckPoint : MonoBehaviour
{

    public GameObject aliveGO;
    public GameObject aliveGO2;
    private Rigidbody2D rbAlive;
    public Animator aliveAnim;
    private GameMaster gm;
    private bool first = false;
    public float x_value;
    public float y_value;
    private float heal;
    public Canvas canvas;


    private void Start()
    {
          canvas.transform.GetChild(0).gameObject.SetActive(false);
         aliveGO = transform.Find("Broken Top").gameObject; 
         aliveAnim = aliveGO.GetComponent<Animator>();
         rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        
        aliveGO2.SetActive(false);
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


        if (Input.GetKey(KeyCode.E) && !first && collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Checkpoint");
            first = true;
            aliveGO2.SetActive(true);
            aliveGO.SetActive(false);
            aliveAnim.SetBool("on", true);
            gm.lastCheckPointPos = transform.position;
            heal = FindObjectOfType<PlayerStats>().MaxHealth;
            FindObjectOfType<PlayerStats>().Heal(heal);
            FindObjectOfType<Currency>().SaveSettings();
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
            SavePlayer(gm.lastCheckPointPos.x, gm.lastCheckPointPos.y,gm.lastCheckPointPos.z);
            if (PlayerPrefs.GetInt("Scene") == 1)
            {
                FindObjectOfType<Scene0SaveScript>().SaveValues();
            }
            else if (PlayerPrefs.GetInt("Scene") == 2)
            {
                Debug.Log("Went to here Save 1");
                FindObjectOfType<Scene1Save>().SaveValues();
            }
            
            
           
        }
    }



    public void SavePlayer(float x, float y,float z)
    {
        SaveSystem.SavePlayer(x, y,z);
    }






    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            first = false;

        }



    }



}
