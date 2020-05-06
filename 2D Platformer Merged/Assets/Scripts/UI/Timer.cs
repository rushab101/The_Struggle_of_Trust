using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    //------------------------------------------------------//
    float currentTime = 0f;
    float startTime = 300f;
    public Text CountDownText;
    //------------------------------------------------------//


    // Start is called before the first frame update
    void Start() {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update() {
        if (currentTime > 0) {
            currentTime -= 1 * Time.deltaTime;
            //print (currentTime);
            CountDownText.text = currentTime.ToString("0");
        }

        if (currentTime >= 50f) { CountDownText.color = Color.white; }
        if (currentTime < 50f) { CountDownText.color = Color.red; }
        if (currentTime <= 0) {
            FindObjectOfType<PlayerController>().GameOver();
        }

    }
}
