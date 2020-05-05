using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemyController : MonoBehaviour
{
   private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;
    private int facingDirection, damageDirection;

    private Vector2 movement;
    private bool groundDetected, wallDetected;

    [SerializeField]
    private float
        groundCheckDistance, wallCheckDistance, movementSpeed, maxHealth, knockbackDuration; 
    [SerializeField]
    private Transform
    groundCheck, wallCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Vector2 knockbackSpeed;
    [SerializeField]
    private GameObject
        hitParticle,
        deathChunckParticle,
        DeathBloodParticle;


    private float currentHealth, knowckbackStartTime;

    private GameObject Slime;
    private Rigidbody2D SlimeRb;
    private Animator SlimeAnim;

    private void Start()
    {
        Slime = transform.Find("Slime").gameObject;
        SlimeRb = Slime.GetComponent<Rigidbody2D>();
        facingDirection = 1;
        currentHealth = maxHealth;
        SlimeAnim = Slime.GetComponent<Animator>();
    }


    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateknockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }
    //-- Walking State ---//
    private void EnterWalkingState()
    {

    }
    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        //Debug.Log(wallDetected);
        if (!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, SlimeRb.velocity.y);
            SlimeRb.velocity = movement;
        }
    }
    private void ExitWalkingState()
    {


    }
    //------------------//

    //-- Knockback State ---//
    private void EnterknockbackState()
    {
        knowckbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        SlimeRb.velocity = movement;
        SlimeAnim.SetBool("Knockback", true);

    }
    private void UpdateknockbackState()
    {
        if (Time.time >= knowckbackStartTime + knockbackDuration)
        {
            SwitchState(State.Walking);
        }
    }
    private void ExitknockbackState()
    {
        SlimeAnim.SetBool("Knockback", false);

    }
    //------------------//

    //-- Dead State ---//
    private void EnterDeadState()
    {
        Instantiate(deathChunckParticle, Slime.transform.position, deathChunckParticle.transform.rotation);
        Instantiate(DeathBloodParticle, Slime.transform.position, DeathBloodParticle.transform.rotation);
        //Spawn chucks and blood
        Destroy(gameObject);

    }
    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {


    }
    //------------------//
    private void Flip()
    {
        facingDirection *= -1;
        Slime.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    //-----Other functions --///


    private void Damage(float[] attackDetails)
    {
        currentHealth -= attackDetails[0];
        Instantiate(hitParticle, Slime.transform.position,Quaternion.Euler(0.0f,0.0f,UnityEngine.Random.Range(0.0f, 360.0f)));
        if (attackDetails[1] > Slime.transform.position.x)
        {
            damageDirection = -1;
        }
        else
        {
            damageDirection = 1;
        }

        // Hit particle

        if (currentHealth > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if (currentHealth <= 0.0f)
        {
            SwitchState(State.Dead);
        }

    }



    private void SwitchState(State state)
    {
        switch(currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Knockback:
                ExitknockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }
        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Knockback:
                EnterknockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }




}
