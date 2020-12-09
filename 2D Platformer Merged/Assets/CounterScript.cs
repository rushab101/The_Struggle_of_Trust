using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public int counter = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //        Debug.Log("Went into trigger");
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                counter++;
                 FindObjectOfType<AudioManager>().Play("break"); // 06 June 2020

            }

        }

    }
}
