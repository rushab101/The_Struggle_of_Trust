using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefScripty : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thePlayer;
    public float xPos;
    public float yPos;
    
    void Start()
    {
        thePlayer.transform.position = new Vector2(0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos = thePlayer.transform.position.x;
        yPos = thePlayer.transform.position.z;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
