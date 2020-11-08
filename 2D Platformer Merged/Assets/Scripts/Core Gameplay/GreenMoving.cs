using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMoving : MonoBehaviour
{

    [SerializeField]
    private Vector3 velocity;
    public bool moving;
    public bool org_move_down = true;

    private bool move_right = false;
    public bool move_right_2 = false;
    public bool move_right_3 = false;
    public bool move_right_4 = false;
    public bool move_right_5 = false;
    public bool move_right_6 = false;
    public bool move_up = false;

    public bool move_down1 = false;
    public bool move_down2 = false;
    public bool move_down3 = false;
    public bool move_down4 = false;
    private bool resetPlatform = false;
    [SerializeField]
    private GameObject GreenPlatform;

    //public GameObject prefab;
    private GameObject aliveGO;

    private int counter = 0;
    private Vector3 initialPosition;
    private Vector3 pos;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //   Instantiate(prefab, initialPosition, Quaternion.identity);

        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //   moving = false;
            collision.collider.transform.SetParent(null);

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        aliveGO = transform.Find("Green Room Moving Parent").gameObject;
        pos = aliveGO.transform.position;
        initialPosition = transform.localPosition;
    }
    private void Update() {
        
        
    }

    private void FixedUpdate()
    {
        if (FindObjectOfType<ResetGreen>().fell_in)
            {
               //transform.position = pos;
                transform.localPosition = new Vector3(179.5f,-26.34f,10.47732f);
                 moving = false;
                 org_move_down = true;
                move_right = false;
                move_right_2 = false;
                move_right_3 = false;
                move_right_4 = false;
                move_right_5 = false;
                move_right_6 = false;
                move_up = false;
                move_down1 = false;
                move_down2 = false;
                move_down3 = false;
                move_down4 = false;
                resetPlatform = false;
                // StartCoroutine(Test2());
                FindObjectOfType<ResetGreen>().fell_in = false;

            }

        else if (moving)
        {
            

            if (org_move_down)
            {


                  velocity = new Vector3(0,-5,0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y < -64)
                {
                    org_move_down = false;
                    move_right = true;
                }

            }
            else if (move_right)
            {

                velocity = new Vector3(5, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 184)
                {
                    move_down1 = true;
                    move_right = false;

                }

            }
            else if (move_down1)
            {
                velocity = new Vector3(0, -5, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y <= -111)
                {
                    move_down1 = false;
                    move_right_2 = true;
                }
            }
            else if (move_right_2)
            {
                velocity = new Vector3(5, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 215)
                {
                    move_down2 = true;
                    move_right_2 = false;

                }
            }
            else if (move_down2)
            {
                velocity = new Vector3(0, -5, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y <= -140)
                {
                    move_down2 = false;
                    move_right_3 = true;
                }
            }
            else if (move_right_3)
            {
                velocity = new Vector3(5, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 262)
                {
                    move_down3 = true;
                    move_right_3 = false;
                }
            }
            else if (move_down3)
            {
                velocity = new Vector3(0, -5, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y <= -186)
                {
                    move_down3 = false;
                    move_right_4 = true;
                }

            }
            else if (move_right_4)
            {
                velocity = new Vector3(5, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 351)
                {
                    move_right_4 = false;
                    move_up = true;
                }
            }
            else if (move_up)
            {
                velocity = new Vector3(0, 5, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y > -164)
                {
                    move_up = false;
                    move_right_5 = true;
                }
            }
            else if (move_right_5)
            {
                velocity = new Vector3(5, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 400)
                {
                    move_right_5 = false;
                    move_down4 = true;
                }
            }
            else if (move_down4)
            {
                velocity = new Vector3(0, -5, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.y <= -265)
                {
                    move_down4 = false;
                    move_right_6 = true;
                }
            }
            else if (move_right_6)
            {
                velocity = new Vector3(3, 0, 0);
                transform.localPosition += (velocity * Time.deltaTime);
                if (transform.localPosition.x >= 470)
                {
                    move_right_6 = false;
                    moving = false;
                    resetPlatform = true;
                    //transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 100f *Time.deltaTime);
                }
            }

            else
            {
                resetPlatform = true;
            }


            //  Debug.Log(transform.localPosition);
        }


        else if (resetPlatform)
        {


            // velocity = new Vector3(5,0,0);
            //   Destroy(GreenPlatform,0);
            counter = 0;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 100f * Time.deltaTime);


        }

    }

    



}
