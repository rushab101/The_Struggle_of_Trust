using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    //------------------------------------------------------//
    public int health;
    public int num_of_hearts = 5;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;
    //------------------------------------------------------//
    private PlayerController PC;


    private bool GameOver= false;

    // Start is called before the first frame update
    void Start() {
        health = 5;
        PC = GetComponent<PlayerController>();
        //StartCoroutine(Test());

    }

    // Update is called once per frame
    void Update() {
        Health();
        if (GameOver)
        {
            StartCoroutine(Test());
           // FindObjec.GameOver();
        }

    }

    private void Health() {
        //UnityEngine.Debug.Log("Went to here\n");
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].sprite = fullheart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }
            if (i < num_of_hearts) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }

    public void EndGame() {
        UnityEngine.Debug.Log("Went to here\n");
        if (!FindObjectOfType<PlayerCombatController>().DoNotDamage)
        {
             health--;
        }
       
        FindObjectOfType<PlayerController>().anim.SetBool("playerDead", false);
        UnityEngine.Debug.Log("Health left: " + health);
        if (health <= 0)
        {
            GameOver = true;
            //PlayerisDead
           
            FindObjectOfType<PlayerStats>().Die();
            //StartCoroutine(Test());
           // FindObjectOfType<PlayerController>().GameOver();

        }
    }

   
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Hi");


        SceneManager.LoadScene("Game Over");
    }


}
