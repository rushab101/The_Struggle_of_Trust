using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRoomLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject BluePlatform;

    [SerializeField]
    private GameObject BluePlatform2;
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


    void Start()
    {
        BluePlatform.SetActive(false);
        BluePlatform2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (e1 == null && e2 == null && e3 == null && e4 == null && e5 == null && e6 == null)
        {
             BluePlatform.SetActive(true);
        }
         if (!e7.active && !e8.active && !e9.active)
        {
           BluePlatform2.SetActive(true);
        }
        
    }
}
