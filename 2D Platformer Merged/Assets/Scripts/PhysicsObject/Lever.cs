using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    private bool went_it = false;
    public bool open_Gate = false;
    public bool open_portal = false;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject gate;

    void Start()
    {
        gate.SetActive(true);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {


        if (Input.GetKey(KeyCode.Z) && !went_it)
        {

            FindObjectOfType<AudioManager>().Play("LeverHit"); // 06 June 2020
           // Debug.Log("It went in here");
            //  c.SetActive(true);
            went_it = true;
            anim.SetBool("done", true);
            open_portal = true;

            StartCoroutine(Test2());



            //  door1.SetActive(false);
            //   door2.SetActive(true);


        }
    }




    IEnumerator Test2()
    {

        yield return new WaitForSecondsRealtime(0.2f);

        open_portal = true;
        anim.SetBool("done", false);
        anim.SetBool("cancel", true);
        a.SetActive(false);
        b.SetActive(false);
        gate.SetActive(false);
        open_Gate = true;



    }
}
