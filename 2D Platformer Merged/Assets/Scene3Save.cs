using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Save : MonoBehaviour
{


    private Animator Red_Lever_anim;
    private Animator Blue_Lever_anim;
    private Animator Green_Lever_anim;
    private Animator Yellow_Lever_anim;
      public GameObject RedWall;
    public GameObject BlueWall;
    public GameObject GreenWall;
    public GameObject YellowWall;
    public Canvas canvas;



    void Start()
    {

        Red_Lever_anim = GameObject.Find("Lever").GetComponent<Animator>(); //Red Lever
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        Blue_Lever_anim = GameObject.Find("Blue Lever").GetComponent<Animator>();
        Green_Lever_anim = GameObject.Find("Green Lever").GetComponent<Animator>();
        Yellow_Lever_anim = GameObject.Find("Yellow Lever").GetComponent<Animator>();


        //   PlayerPrefs.DeleteAll();
    }


    // Start is called before the first frame update\

    // Update is called once per frame
    void Update()
    {
          if (!Red_Lever_anim.GetBool("done") && Red_Lever_anim.GetBool("cancel"))
        {
            //            Debug.Log("In here");
            if (PlayerPrefs.GetInt("Red Lever Complete Soft") == 0)
            {
                PlayerPrefs.SetInt("Red Lever Complete Soft", 2);
                show_save_icon();
                // RedWall.SetActive(true);
            }



        }

        if (PlayerPrefs.GetInt("Red Lever Complete Soft") == 1 || PlayerPrefs.GetInt("Red Lever Complete Soft") == 2)
        {
            Red_Lever_anim.SetBool("done", false);
            Red_Lever_anim.SetBool("cancel", true);
            RedWall.SetActive(false);
        }



        //-------------Blue Lever Save Case-------------------------------------\\
        if (!Blue_Lever_anim.GetBool("done") && Blue_Lever_anim.GetBool("cancel"))
        {
            //   Debug.Log("In here");
            if (PlayerPrefs.GetInt("Blue Lever Complete Soft") == 0)
            {
                PlayerPrefs.SetInt("Blue Lever Complete Soft", 2);
                show_save_icon();
                // RedWall.SetActive(true);
            }



        }

        if (PlayerPrefs.GetInt("Blue Lever Complete Soft") == 1 || PlayerPrefs.GetInt("Blue Lever Complete Soft") == 2)
        {
            Blue_Lever_anim.SetBool("done", false);
            Blue_Lever_anim.SetBool("cancel", true);
            BlueWall.SetActive(false);
         
        }


        //-------------Green Lever Save Case-------------------------------------\\
        if (!Green_Lever_anim.GetBool("done") && Green_Lever_anim.GetBool("cancel"))
        {
            Debug.Log("In here");
            if (PlayerPrefs.GetInt("Green Lever Complete Soft") == 0)
            {
                PlayerPrefs.SetInt("Green Lever Complete Soft", 2);
                show_save_icon();
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Green Lever Complete Soft") == 1 || PlayerPrefs.GetInt("Green Lever Complete Soft") == 2)
        {
            Debug.Log("In here 2");
            Green_Lever_anim.SetBool("done", false);
            Green_Lever_anim.SetBool("cancel", true);
            GreenWall.SetActive(false);

        }

        //--------------Yellow Lever Case -----------------------------------\\
          //-------------Green Lever Save Case-------------------------------------\\
        if (!Yellow_Lever_anim.GetBool("done") && Yellow_Lever_anim.GetBool("cancel"))
        {
            Debug.Log("In here 5");
            if (PlayerPrefs.GetInt("Yellow Lever Complete Soft") == 0)
            {
                PlayerPrefs.SetInt("Yellow Lever Complete Soft", 2);
                show_save_icon();
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Yellow Lever Complete Soft") == 1 || PlayerPrefs.GetInt("Yellow Lever Complete Soft") == 2)
        {
            Debug.Log("In here 2");
            Yellow_Lever_anim.SetBool("done", false);
            Yellow_Lever_anim.SetBool("cancel", true);
            YellowWall.SetActive(false);

        }



    }


    public void show_save_icon()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        //  Debug.Log("Hi");
        //  anim.SetBool("setAttack", false);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }




}
