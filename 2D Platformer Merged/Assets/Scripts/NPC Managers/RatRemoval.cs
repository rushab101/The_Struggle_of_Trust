using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRemoval : MonoBehaviour
{

     [SerializeField]
    private GameObject YellowGate;

    // Start is called before the first frame update

       [SerializeField]
    private GameObject e1;

    [SerializeField]
    private GameObject e2;

    [SerializeField]
    private GameObject e3;

    [SerializeField]
    private GameObject e4;

    [SerializeField]
    private GameObject e5;

    [SerializeField]
    private GameObject e6;

    
    [SerializeField]
    private GameObject e7;

    [SerializeField]
    private GameObject e8;

    [SerializeField]
    private GameObject e9;

     [SerializeField]
    private GameObject e10;


    // Start is called before the first frame update
    void Start()
    {
        YellowGate.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!e1.active && !e2.active && !e3.active&& !e4.active && !e5.active && !e6.active && !e7.active && !e8.active && !e9.active && !e10.active)
        {
           YellowGate.SetActive(false);
        }
    }
}
