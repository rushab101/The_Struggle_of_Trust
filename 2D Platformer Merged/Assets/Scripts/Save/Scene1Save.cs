using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Save : MonoBehaviour
{
    private GameObject RedLever;

    public GameObject GreenLever;
    public GameObject BlueLever;

    private Animator Red_Lever_anim;
    private Animator Blue_Lever_anim;
    private Animator Green_Lever_anim;
    SpriteRenderer rend;
    public Canvas canvas;

    public GameObject RedWall;
    public GameObject BlueWall;
    public GameObject BlueWall1;
    public GameObject GreenWall;

    public GameObject PurpleCoin1;
    public GameObject PurpleCoin2;
    public GameObject PurpleCoin3;
    public GameObject PurpleCoin4;
    public GameObject Create1;
    public GameObject Create2;
    public GameObject Create3;
    public GameObject Create4;
    public GameObject Create5;
    public GameObject Create6;
    public GameObject Create7;
    public GameObject Create8;
    public GameObject Create9;
    public GameObject Create10;
    public GameObject Create11;
    public GameObject Create12;
    public GameObject Create13;
    public GameObject Create14;
    public GameObject miniBoss_idle;
    public GameObject boss_trigger;
    private GameObject Create1_child;
    private GameObject Create2_child;
    private GameObject Create3_child;
    private GameObject Create4_child;
    private GameObject Create5_child;
    private GameObject Create6_child;
    private GameObject Create7_child;
    private GameObject Create8_child;
    private GameObject Create9_child;
    private GameObject Create10_child;
    private GameObject Create11_child;
    private GameObject Create12_child;
    private GameObject Create13_child;
    private GameObject Create14_child;




    void Start()
    {

        Red_Lever_anim = GameObject.Find("Lever").GetComponent<Animator>(); //Red Lever
        canvas.transform.GetChild(0).gameObject.SetActive(false);                                                  // PlayerPrefs.SetInt("Red Lever Complete Soft", 0);
        Blue_Lever_anim = GameObject.Find("Blue Lever").GetComponent<Animator>();
        Green_Lever_anim = GameObject.Find("Green Lever").GetComponent<Animator>();
        Create1_child = Create1.transform.GetChild(0).gameObject;
        Create2_child = Create2.transform.GetChild(0).gameObject;
        Create3_child = Create3.transform.GetChild(0).gameObject;
        Create4_child = Create4.transform.GetChild(0).gameObject;
        Create5_child = Create5.transform.GetChild(0).gameObject;
        Create6_child = Create6.transform.GetChild(0).gameObject;
        Create7_child = Create8.transform.GetChild(0).gameObject;
        Create8_child = Create8.transform.GetChild(0).gameObject;
        Create9_child = Create9.transform.GetChild(0).gameObject;
        Create10_child = Create10.transform.GetChild(0).gameObject;
        Create11_child = Create11.transform.GetChild(0).gameObject;
        Create12_child = Create12.transform.GetChild(0).gameObject;
        Create13_child = Create13.transform.GetChild(0).gameObject;
        Create14_child = Create14.transform.GetChild(0).gameObject;
        rend = BlueLever.GetComponent<SpriteRenderer>();

           PlayerPrefs.DeleteAll();
    }




    void Update()
    {

        //-------------Red Lever Save Case-------------------------------------\\
        //Soft Save
        // Debug.Log(RedLever.GetComponent<Animator>().GetBool("done"));
        // Debug.Log("Cancel is " + Red_Lever_anim.GetBool("cancel"));

        //    Debug.Log("Value is:  " + PlayerPrefs.GetInt("Red Lever Complete Soft"));

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
            BlueWall1.SetActive(false);
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





        //Hard Save
        //-------------4 Purple Coin Save Case-------------------------------------\\
        //Soft Save
        //Coin 1
        if (!PurpleCoin1.activeSelf)
        {
            if (PlayerPrefs.GetInt("PurpleCoin1") == 0)
            {
                PlayerPrefs.SetInt("PurpleCoin1", 1);
                // RedWall.SetActive(true);
            }

        }
        //        Debug.Log(PlayerPrefs.GetInt("PurpleCoin1"));
        if (PlayerPrefs.GetInt("PurpleCoin1") == 1 || PlayerPrefs.GetInt("PurpleCoin1") == 2)
        {
            PurpleCoin1.SetActive(false);
        }
        //Coin 2

        //     Debug.Log(PlayerPrefs.GetInt("PurpleCoin2"));
        if (!PurpleCoin2.activeSelf)
        {
            if (PlayerPrefs.GetInt("PurpleCoin2") == 0)
            {
                PlayerPrefs.SetInt("PurpleCoin2", 1);
                // RedWall.SetActive(true);
            }

        }
        if (PlayerPrefs.GetInt("PurpleCoin2") == 1 || PlayerPrefs.GetInt("PurpleCoin2") == 2)
        {
            //            Debug.Log("In here Coin 2");
            PurpleCoin2.SetActive(false);
        }

        //Coin 3
        if (!PurpleCoin3.activeSelf)
        {
            if (PlayerPrefs.GetInt("PurpleCoin3") == 0)
            {
                PlayerPrefs.SetInt("PurpleCoin3", 1);
                // RedWall.SetActive(true);
            }

        }
        if (PlayerPrefs.GetInt("PurpleCoin3") == 1 || PlayerPrefs.GetInt("PurpleCoin3") == 2)
        {
            PurpleCoin3.SetActive(false);
        }

        //Coin 4
        if (!PurpleCoin4.activeSelf)
        {
            if (PlayerPrefs.GetInt("PurpleCoin4") == 0)
            {
                PlayerPrefs.SetInt("PurpleCoin4", 1);
                // RedWall.SetActive(true);
            }

        }
        if (PlayerPrefs.GetInt("PurpleCoin4") == 1 || PlayerPrefs.GetInt("PurpleCoin4") == 2)
        {
            PurpleCoin4.SetActive(false);
        }


        //-------------Creates Save Case-------------------------------------\\
        //Soft Save
        //Create 1
        if (!Create1_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create1") == 0)
            {
                PlayerPrefs.SetInt("Create1", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create1") == 1 || PlayerPrefs.GetInt("Create1") == 2)
        {
            Create1_child.SetActive(false);
        }
        //Create 2
        if (!Create2_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create2") == 0)
            {
                PlayerPrefs.SetInt("Create2", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create2") == 1 || PlayerPrefs.GetInt("Create2") == 2)
        {
            Create2_child.SetActive(false);
        }
        //Create 3
        if (!Create3_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create3") == 0)
            {
                PlayerPrefs.SetInt("Create3", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create3") == 1 || PlayerPrefs.GetInt("Create3") == 2)
        {
            Create3_child.SetActive(false);
        }
        //Create 4
        if (!Create4_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create4") == 0)
            {
                PlayerPrefs.SetInt("Create4", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create4") == 1 || PlayerPrefs.GetInt("Create4") == 2)
        {
            Create4_child.SetActive(false);
        }
        //Create 5
        if (!Create5_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create5") == 0)
            {
                PlayerPrefs.SetInt("Create5", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create5") == 1 || PlayerPrefs.GetInt("Create5") == 2)
        {
            Create5_child.SetActive(false);
        }
        //Create 6
        if (!Create6_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create6") == 0)
            {
                PlayerPrefs.SetInt("Create6", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create6") == 1 || PlayerPrefs.GetInt("Create6") == 2)
        {
            Create6_child.SetActive(false);
        }
        //Create 7
        if (!Create7_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create7") == 0)
            {
                PlayerPrefs.SetInt("Create7", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create7") == 1 || PlayerPrefs.GetInt("Create7") == 2)
        {
            Create7_child.SetActive(false);
        }
        //Create 8
        if (!Create8_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create8") == 0)
            {
                PlayerPrefs.SetInt("Create8", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create8") == 1 || PlayerPrefs.GetInt("Create8") == 2)
        {
            Create8_child.SetActive(false);
        }
        //Create 9
        if (!Create9_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create9") == 0)
            {
                PlayerPrefs.SetInt("Create9", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create9") == 1 || PlayerPrefs.GetInt("Create9") == 2)
        {
            Create9_child.SetActive(false);
        }
        //Create 10
        if (!Create10_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create10") == 0)
            {
                PlayerPrefs.SetInt("Create10", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create10") == 1 || PlayerPrefs.GetInt("Create10") == 2)
        {
            Create10_child.SetActive(false);
        }
        //Create 11
        if (!Create11_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create11") == 0)
            {
                PlayerPrefs.SetInt("Create11", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create11") == 1 || PlayerPrefs.GetInt("Create11") == 2)
        {
            Create11_child.SetActive(false);
        }
        //Create 12
        if (!Create12_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create12") == 0)
            {
                PlayerPrefs.SetInt("Create12", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create12") == 1 || PlayerPrefs.GetInt("Create12") == 2)
        {
            Create12_child.SetActive(false);
        }
        //Create 13
        if (!Create13_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create13") == 0)
            {
                PlayerPrefs.SetInt("Create13", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create13") == 1 || PlayerPrefs.GetInt("Create13") == 2)
        {
            Create13_child.SetActive(false);
        }
        //Create 14
        if (!Create14_child.activeSelf)
        {
            if (PlayerPrefs.GetInt("Create14") == 0)
            {
                PlayerPrefs.SetInt("Create14", 1);
                // RedWall.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("Create14") == 1 || PlayerPrefs.GetInt("Create14") == 2)
        {
            Create14_child.SetActive(false);
        }
        if (FindObjectOfType<BossTrigger1>().boss_is_dead_complete)
        {
            if (PlayerPrefs.GetInt("MiniBoss") == 0)
            {
                PlayerPrefs.SetInt("MiniBoss", 2);
                show_save_icon();
                // RedWall.SetActive(true);
            }

        }
        if (PlayerPrefs.GetInt("MiniBoss") == 1 || PlayerPrefs.GetInt("MiniBoss") == 2)
        {
            miniBoss_idle.SetActive(false);
            boss_trigger.SetActive(false);
            BlueLever.SetActive(true);
            Color c = rend.material.color;
            c.a = 1f;
            rend.material.color = c;


        }






    }

    public void OnApplicationQuit()
    {

        if (PlayerPrefs.GetInt("Red Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Red Lever Complete Soft", 0);
            RedWall.SetActive(true);
            Red_Lever_anim.SetBool("done", false);
            Red_Lever_anim.SetBool("cancel", false);
        }
        if (PlayerPrefs.GetInt("Blue Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Blue Lever Complete Soft", 0);
            BlueWall.SetActive(true);
            BlueWall1.SetActive(true);
            Blue_Lever_anim.SetBool("done", false);
            Blue_Lever_anim.SetBool("cancel", false);
        }
        if (PlayerPrefs.GetInt("Green Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Green Lever Complete Soft", 0);
            GreenWall.SetActive(true);
            Green_Lever_anim.SetBool("done", false);
            Green_Lever_anim.SetBool("cancel", false);
        }
        if (PlayerPrefs.GetInt("PurpleCoin2") == 1)
        {
            Debug.Log("Coin 2");
            PlayerPrefs.SetInt("PurpleCoin2", 0);
            PurpleCoin2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PurpleCoin1") == 1)
        {
            Debug.Log("Coin 1");
            PlayerPrefs.SetInt("PurpleCoin1", 0);
            PurpleCoin1.SetActive(true);
        }
        //    Debug.Log("Purple Coin 2" + PlayerPrefs.GetInt("PurpleCoin2"));

        if (PlayerPrefs.GetInt("PurpleCoin3") == 1)
        {
            Debug.Log("Coin 3");
            PlayerPrefs.SetInt("PurpleCoin3", 0);
            PurpleCoin3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PurpleCoin4") == 1)
        {
            Debug.Log("Coin 4");
            PlayerPrefs.SetInt("PurpleCoin4", 0);
            PurpleCoin4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create1") == 1)
        {
            PlayerPrefs.SetInt("Create1", 0);
            Create1_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create2") == 1)
        {
            PlayerPrefs.SetInt("Create2", 0);
            Create2_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create3") == 1)
        {
            PlayerPrefs.SetInt("Create3", 0);
            Create3_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create4") == 1)
        {
            PlayerPrefs.SetInt("Create4", 0);
            Create4_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create5") == 1)
        {
            PlayerPrefs.SetInt("Create5", 0);
            Create5_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create6") == 1)
        {
            PlayerPrefs.SetInt("Create6", 0);
            Create6_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create7") == 1)
        {
            PlayerPrefs.SetInt("Create7", 0);
            Create7_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create8") == 1)
        {
            PlayerPrefs.SetInt("Create8", 0);
            Create8_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create9") == 1)
        {
            PlayerPrefs.SetInt("Create9", 0);
            Create9_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create10") == 1)
        {
            PlayerPrefs.SetInt("Create10", 0);
            Create10_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create11") == 1)
        {
            PlayerPrefs.SetInt("Create11", 0);
            Create11_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create12") == 1)
        {
            PlayerPrefs.SetInt("Create12", 0);
            Create12_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create13") == 1)
        {
            PlayerPrefs.SetInt("Create13", 0);
            Create13_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create14") == 1)
        {
            PlayerPrefs.SetInt("Create14", 0);
            Create14_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create14") == 1)
        {
            PlayerPrefs.SetInt("Create14", 0);
            Create14_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MiniBoss") == 1)
        {
            PlayerPrefs.SetInt("MiniBoss", 0);
            miniBoss_idle.SetActive(true);
            boss_trigger.SetActive(true);
            BlueLever.SetActive(false);
        }
        if (FindObjectOfType<PlayerStats>().GameOver)
        {
            ResetValues();
        }
    }

    public void ResetValues()
    {
        if (PlayerPrefs.GetInt("Red Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Red Lever Complete Soft", 0);
            RedWall.SetActive(true);
            Red_Lever_anim.SetBool("done", false);
            Red_Lever_anim.SetBool("cancel", false);

        }
        if (PlayerPrefs.GetInt("Blue Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Blue Lever Complete Soft", 0);
            BlueWall.SetActive(true);
            BlueWall1.SetActive(true);
            Blue_Lever_anim.SetBool("done", false);
            Blue_Lever_anim.SetBool("cancel", false);
        }
        if (PlayerPrefs.GetInt("Green Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Green Lever Complete Soft", 0);
            GreenWall.SetActive(true);
            Green_Lever_anim.SetBool("done", false);
            Green_Lever_anim.SetBool("cancel", false);
        }
        if (PlayerPrefs.GetInt("PurpleCoin2") == 1)
        {
            //  Debug.Log("Coin 2");
            PlayerPrefs.SetInt("PurpleCoin2", 0);
            PurpleCoin2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PurpleCoin1") == 1)
        {
            //   Debug.Log("Coin 1");
            PlayerPrefs.SetInt("PurpleCoin1", 0);
            PurpleCoin1.SetActive(true);
        }
        //    Debug.Log("Purple Coin 2" + PlayerPrefs.GetInt("PurpleCoin2"));

        if (PlayerPrefs.GetInt("PurpleCoin3") == 1)
        {
            //   Debug.Log("Coin 3");
            PlayerPrefs.SetInt("PurpleCoin3", 0);
            PurpleCoin3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PurpleCoin4") == 1)
        {
            //   Debug.Log("Coin 4");
            PlayerPrefs.SetInt("PurpleCoin4", 0);
            PurpleCoin4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create1") == 1)
        {
            PlayerPrefs.SetInt("Create1", 0);
            Create1_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create2") == 1)
        {
            PlayerPrefs.SetInt("Create2", 0);
            Create2_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create3") == 1)
        {
            PlayerPrefs.SetInt("Create3", 0);
            Create3_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create4") == 1)
        {
            PlayerPrefs.SetInt("Create4", 0);
            Create4_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create5") == 1)
        {
            PlayerPrefs.SetInt("Create5", 0);
            Create5_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create6") == 1)
        {
            PlayerPrefs.SetInt("Create6", 0);
            Create6_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create7") == 1)
        {
            PlayerPrefs.SetInt("Create7", 0);
            Create7_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create8") == 1)
        {
            PlayerPrefs.SetInt("Create8", 0);
            Create8_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create9") == 1)
        {
            PlayerPrefs.SetInt("Create9", 0);
            Create9_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create10") == 1)
        {
            PlayerPrefs.SetInt("Create10", 0);
            Create10_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create11") == 1)
        {
            PlayerPrefs.SetInt("Create11", 0);
            Create11_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create12") == 1)
        {
            PlayerPrefs.SetInt("Create12", 0);
            Create12_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create13") == 1)
        {
            PlayerPrefs.SetInt("Create13", 0);
            Create13_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create14") == 1)
        {
            PlayerPrefs.SetInt("Create14", 0);
            Create14_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Create14") == 1)
        {
            PlayerPrefs.SetInt("Create14", 0);
            Create14_child.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MiniBoss") == 1)
        {
            PlayerPrefs.SetInt("MiniBoss", 0);
            miniBoss_idle.SetActive(true);
            boss_trigger.SetActive(true);
            BlueLever.SetActive(false);
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



    public void SaveValues()
    {
        //-------------Red Lever Save Case-------------------------------------\\
        //Soft Save
        // Debug.Log(RedLever.GetComponent<Animator>().GetBool("done"));
        Debug.Log("Cancel is " + Green_Lever_anim.GetBool("cancel"));




        if (PlayerPrefs.GetInt("Red Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Red Lever Complete Soft", 2);

        }




        if (PlayerPrefs.GetInt("Blue Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Blue Lever Complete Soft", 2);
        }



        if (PlayerPrefs.GetInt("Green Lever Complete Soft") == 1)
        {
            PlayerPrefs.SetInt("Green Lever Complete Soft", 2);

        }



        if (PlayerPrefs.GetInt("PurpleCoin1") == 1)
        {
            PlayerPrefs.SetInt("PurpleCoin1", 2);
        }
        //Coin 2


        if (PlayerPrefs.GetInt("PurpleCoin2") == 1)
        {
            PlayerPrefs.SetInt("PurpleCoin2", 2);
        }

        //Coin 3

        if (PlayerPrefs.GetInt("PurpleCoin3") == 1)
        {
            PlayerPrefs.SetInt("PurpleCoin3", 2);
        }

        //Coin 4

        if (PlayerPrefs.GetInt("PurpleCoin4") == 1)
        {
            PlayerPrefs.SetInt("PurpleCoin4", 2);
        }


        //-------------Creates Save Case-------------------------------------\\
        //Soft Save
        //Create 1

        if (PlayerPrefs.GetInt("Create1") == 1)
        {
            PlayerPrefs.SetInt("Create1", 2);
        }
        //Create 2

        if (PlayerPrefs.GetInt("Create2") == 1)
        {
            PlayerPrefs.SetInt("Create2", 2);
        }
        //Create 3

        if (PlayerPrefs.GetInt("Create3") == 1)
        {
            PlayerPrefs.SetInt("Create3", 2);
        }
        //Create 4

        if (PlayerPrefs.GetInt("Create4") == 1)
        {
            PlayerPrefs.SetInt("Create4", 2);
        }
        //Create 5

        if (PlayerPrefs.GetInt("Create5") == 1)
        {
            PlayerPrefs.SetInt("Create5", 2);
        }
        //Create 6

        if (PlayerPrefs.GetInt("Create6") == 1)
        {
            PlayerPrefs.SetInt("Create6", 2);
        }
        //Create 7

        if (PlayerPrefs.GetInt("Create7") == 1)
        {
            PlayerPrefs.SetInt("Create7", 2);
        }
        //Create 8

        if (PlayerPrefs.GetInt("Create8") == 1)
        {
            PlayerPrefs.SetInt("Create8", 2);
        }
        //Create 9

        if (PlayerPrefs.GetInt("Create9") == 1)
        {
            PlayerPrefs.SetInt("Create9", 2);
        }
        //Create 10

        if (PlayerPrefs.GetInt("Create10") == 1)
        {
            PlayerPrefs.SetInt("Create10", 2);
        }
        //Create 11

        if (PlayerPrefs.GetInt("Create11") == 1)
        {
            PlayerPrefs.SetInt("Create11", 2);
        }
        //Create 12

        if (PlayerPrefs.GetInt("Create12") == 1)
        {
            PlayerPrefs.SetInt("Create12", 2);
        }
        //Create 13

        if (PlayerPrefs.GetInt("Create13") == 1)
        {
            PlayerPrefs.SetInt("Create13", 2);
        }
        //Create 14

        if (PlayerPrefs.GetInt("Create14") == 1)
        {
            PlayerPrefs.SetInt("Create14", 2);
        }

        if (PlayerPrefs.GetInt("MiniBoss") == 1)
        {
            PlayerPrefs.SetInt("MiniBoss", 2);

        }

    }

}
