using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    // control how fast time restores back to normal, and when we started storing time
    private float speed;
    private bool restoreTime;

    void Start() {
        restoreTime = false;
    }

    void Update(){
        if (restoreTime) {
            if (Time.timeScale < 1f) {
                Time.timeScale += Time.deltaTime * speed;
            }
            else {
                Time.timeScale = 1f;
                restoreTime = false;
            }
        }
    }

    public void StopTime(float changeTime, int restoreSpeed, float delay) {

        speed = restoreSpeed;

        if (delay > 0) {
            StopCoroutine(StartTimeAgain(delay));
            StartCoroutine(StartTimeAgain(delay));
        }
        else {
            restoreTime = true;
        }

        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain(float amount) {
        yield return new WaitForSecondsRealtime(amount);
        restoreTime = true;
    }

}
