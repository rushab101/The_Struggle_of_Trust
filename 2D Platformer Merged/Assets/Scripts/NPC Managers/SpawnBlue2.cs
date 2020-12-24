using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlue2 : MonoBehaviour
{

     [SerializeField]
    private GameObject e1;

    [SerializeField]
    private GameObject e2;

    [SerializeField]
    private GameObject e3;

    
    [SerializeField]
    private GameObject BluePlatform;

    [SerializeField]
    private GameObject b1;
    [SerializeField]
    private GameObject b2;
    [SerializeField]
    private GameObject b3;
    public BoxCollider2D box;






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
          if (!e1.active && !e2.active && !e3.active)
        {
          
            box.isTrigger= false;
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
        }
        
    }
}
