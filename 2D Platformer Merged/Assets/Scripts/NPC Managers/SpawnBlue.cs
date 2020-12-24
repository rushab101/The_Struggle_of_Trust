using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlue : MonoBehaviour
{
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
    private GameObject BluePlatform;

    [SerializeField]
    private GameObject b1;
    [SerializeField]
    private GameObject b2;
    [SerializeField]
    private GameObject b3;
    public BoxCollider2D box;


    public bool killed_all = false;
    // Start is called before the first frame update
    void Start()
    {
        box.isTrigger= true;
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (e1 == null && e2 == null && e3 == null && e4 == null && e5 == null && e6 == null)
        {
            box.isTrigger= false;
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            killed_all = true;
        }
       
    }
}
