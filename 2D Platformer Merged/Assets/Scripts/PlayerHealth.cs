using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //------------------------------------------------------//
    public int health;
    public int num_of_hearts = 5;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;
    //------------------------------------------------------//

    // Start is called before the first frame update
    void Start() {
        health = 5;
    }

    // Update is called once per frame
    void Update() {
        Health();

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
        health--;
        UnityEngine.Debug.Log(health);
        if (health <= 0) {
            FindObjectOfType<PlayerController>().GameOver();
        }
    }
}
