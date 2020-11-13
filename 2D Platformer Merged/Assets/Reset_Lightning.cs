using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Lightning : MonoBehaviour
{
    public GameObject a;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        counter++;
        StartCoroutine(Test());
    }

     IEnumerator Test()
    {
        
        yield return new WaitForSecondsRealtime(5f);
        a.SetActive(true);
        yield return new WaitForSecondsRealtime(1.1f);
        a.SetActive(false);
    }
}
