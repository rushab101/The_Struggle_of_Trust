using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aIPath;
     private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;
    private int facingDirection, 
        damageDirection;

    private Vector2 movement,
        touchDamageBotLeft,
        touchDamageTopRight;

    AttackDetails attackDetails;

    private bool groundDetected, wallDetected;

    [SerializeField]
    private float
        groundCheckDistance, 
        wallCheckDistance, 
        movementSpeed, 
        maxHealth, 
        knockbackDuration,
        lastTouchDamageTime, // last time the enemy damaged
        touchDamageCoolDown,
        touchDamage,
        touchDamageWidth,
        touchDamageHeight;
    


    [SerializeField]
    private Transform
    groundCheck, 
     wallCheck,
     touchDamageCheck;

    [SerializeField]
    private LayerMask 
        whatIsGround,
        whatisPlayer;
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
    public bool flying = false;

    private void Start()
    {
        Slime = transform.Find("Wasp").gameObject;
        SlimeRb = Slime.GetComponent<Rigidbody2D>();
        if (SlimeRb == null)
        {
            Debug.Log("SOMETHING IS WRONG");
        }
        facingDirection = 1;
        currentHealth = maxHealth;
        SlimeAnim = Slime.GetComponent<Animator>();
    }

    //------------------//

    //-- Knockback State ---//
    private void EnterknockbackState()
    {
        knowckbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        SlimeRb.velocity = movement;
       // Debug.log()
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


    private void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
        Debug.Log(currentHealth);
        Instantiate(hitParticle, Slime.transform.position,Quaternion.Euler(0.0f,0.0f,UnityEngine.Random.Range(0.0f, 360.0f)));
        

        // Hit particle

        if (currentHealth > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if (currentHealth <= 0.0f)
        {
           EnterDeadState();
        }

    }

    private void CheckTouchDamage()
    {
        if (Time.time >= lastTouchDamageTime + touchDamageCoolDown)
        {
            touchDamageBotLeft.Set(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
            touchDamageTopRight.Set(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));

            Collider2D hit = Physics2D.OverlapArea(touchDamageBotLeft, touchDamageTopRight, whatisPlayer);
            if (hit != null)
            {
               
            }
        }
    }




    private void SwitchState(State state)
    {
        switch(currentState)
        {
           
            case State.Knockback:
                ExitknockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }
        switch (state)
        {
           
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
        Vector2 botLeft = new Vector2(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
        Vector2 botRight= new Vector2(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2)); 
        Vector2 topRight = new Vector2(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2)); 
        Vector2 topLeft = new Vector2(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));
        Gizmos.DrawLine(botLeft, botRight);
        Gizmos.DrawLine(botRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, botLeft);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (aIPath.desiredVelocity.x >=0.01f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        } else if (aIPath.desiredVelocity.x <=-0.01f)
        {
             transform.localScale = new Vector3(1f,1f,1f);
        }
        switch (currentState)
        {
            case State.Knockback:
                UpdateknockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
        
    }

      void OnTriggerEnter2D(Collider2D other)
  {
    
      if (other.CompareTag("Player"))
      {  
           if (Time.time >= lastTouchDamageTime + touchDamageCoolDown)
        {
            flying = true;
            FindObjectOfType<PlayerStats>().TakeDamage(1f);
              FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
        }
           
      }
  }


}
