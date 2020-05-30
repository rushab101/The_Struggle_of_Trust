using System.Collections;
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


    private void Start()
    {
        // aliveGO = transform.Find("Broken Top").gameObject; 
        // aliveAnim = aliveGO.GetComponent<Animator>();
        // rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        aliveGO2.SetActive(false);
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
            heal =  FindObjectOfType<PlayerStats>().MaxHealth; 
            FindObjectOfType<PlayerStats>().Heal(heal);
            SavePlayer(gm.lastCheckPointPos.x, gm.lastCheckPointPos.y);
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<Currency>().SaveSettings();
        }
    }



    public void SavePlayer(float x, float y)
    {
        SaveSystem.SavePlayer(x, y);
    }






    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        first = false;
        
        }
       


    }



}
