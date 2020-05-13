using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    // control how fast time restores back to normal, and when we started storing time
    private float speed;
    private bool restoreTime;

    //public GameObject HitStop;
    private Animator anim;

    public ParticleSystem HitStopParticle;

    void Start() {
        restoreTime = false;
        anim = GetComponentInChildren<Animator>();
    }

    void Update() {
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

    private void enableHitStopParticle() {
        HitStopParticle.Play();
    }


    public void StopTime(float changeTime, int restoreSpeed, float delay) {

        speed = restoreSpeed;

        if (delay > 0) {
            StopCoroutine(StartTimeAgain(delay));
            StartCoroutine(StartTimeAgain(delay));
        }
        else {
            Time.timeScale = 1f;
            restoreTime = true;
            anim.SetBool("ouch", false);
        }

        Instantiate(HitStopParticle, transform.position, Quaternion.identity);
        anim.SetBool("ouch", true);

        enableHitStopParticle();
        //Debug.Log("Enable Hit Particle");

        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain(float amount) {
        yield return new WaitForSecondsRealtime(amount);
        restoreTime = true;
    }

}
