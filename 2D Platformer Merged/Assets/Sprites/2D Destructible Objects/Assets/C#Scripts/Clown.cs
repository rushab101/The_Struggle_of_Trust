using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    public float maxSpeed = 100f;
    public float Speed = 50f;
    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool isMoving = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveRight = false;
            moveLeft = false;
            isMoving = false;
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            moveRight = false;

            if (!isMoving)
            {
                isMoving = true;
                animator.SetFloat("Direction", -1);
                animator.SetTrigger("Move");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            moveLeft = false;

            if (!isMoving)
            {
                isMoving = true;
                animator.SetFloat("Direction", 1);
                animator.SetTrigger("Move");
            }
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
            moveRight = false;
            moveLeft = false;
            animator.SetTrigger("Stand");
        }
    }

    void FixedUpdate()
    {
        float move = 0;

        if (moveLeft)
            move = -1;
        else if (moveRight)
            move = 1;
        

        if (move != 0)
        {
            if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed)
            {
                Vector2 toMove = new Vector2(move * Speed, rigidBody.velocity.y);
                rigidBody.AddForce(toMove);
            }
            
        }
        else if(move == 0)
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
}
