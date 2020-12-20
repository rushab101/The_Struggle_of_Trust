using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnONFlyingAI : MonoBehaviour
{
    public GameObject turnOn;
    // Start is called before the first frame update
    void Start()
    {
        turnOn.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            
            turnOn.SetActive(true);

            
        }
    }
}
