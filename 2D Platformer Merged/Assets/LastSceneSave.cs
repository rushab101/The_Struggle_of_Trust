using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneSave : MonoBehaviour
{
    public GameObject MainGate;
    public GameObject MainGate2;
    public Canvas canvas;
    int get_val = 0;
    int leave  = 0;
    int get_val2 = 0;
    // Start is called before the first frame update
    void Awake()
    {
        get_val = PlayerPrefs.GetInt("NPC_Gate");
    }

    void Start()
    {
        if (get_val == 1)
        {
            MainGate.SetActive(false);
        }
        else{
            MainGate.SetActive(true);
        }
       //   canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            get_val = PlayerPrefs.GetInt("NPC_Gate");
            get_val2 = PlayerPrefs.GetInt("NPC_Gate2");
            if (FindObjectOfType<OpenGateScript>().GateOpen && get_val == 0)
            {
                
                
                PlayerPrefs.SetInt("NPC_Gate",1);
                MainGate.SetActive(false);
                StartCoroutine(Test_T());
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(Test_S());
            }
            if (PlayerPrefs.GetInt("GainLife") == 2 && PlayerPrefs.GetInt("leave") == 0 )
            {
                PlayerPrefs.SetInt("leave",1);
                StartCoroutine(Test_T());
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(Test_S());
                leave+=1;
            }
            if (FindObjectOfType<OpenCaveGate>().GateOpen && get_val == 0)
            {
                PlayerPrefs.SetInt("NPC_Gate2",2);
                MainGate2.SetActive(false);
                StartCoroutine(Test_T());
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(Test_S());
            }
        
    }

      IEnumerator Test_S()
    {
        yield return new WaitForSeconds(1.0f);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
    }
      IEnumerator Test_T()
    {
        yield return new WaitForSeconds(2.0f);
    }



}
