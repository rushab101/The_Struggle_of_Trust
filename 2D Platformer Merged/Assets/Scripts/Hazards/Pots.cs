using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pots : MonoBehaviour
{

       [SerializeField]
    private float maxHealth, knockbackSpeedX, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque; 
    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private GameObject HitParticle;

    private float currentHealth, knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback;

  
    private GameObject aliveGO, brokenTopGO, brokenBotGO , heart;
    private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
    private Animator aliveAnim;

    private void Start() {
        currentHealth = maxHealth;

     //   pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGO = transform.Find("Alive").gameObject; 

        //brokenTopGO = Find("Hearts").gameObject; 
        heart = GameObject.Find("Hearts");
        brokenBotGO = transform.Find("Broken Bottom").gameObject;
        //Debug.Log(aliveGO);

        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        rbBrokenTop = brokenTopGO.GetComponent<Rigidbody2D>();
        rbBrokenBot = brokenBotGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
        heart.SetActive(false);
        brokenTopGO.SetActive(false);
        brokenBotGO.SetActive(false);
       
    }

    private void Update() {
        checkKnockback();
    }

    private void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
       // currentHealth -= attackDetails;
       
       // playerFacingDirection = pc.GetFacingDirection();

        if (attackDetails.position.x < aliveGO.transform.position.x)
        {
            playerFacingDirection = 1;
        }
        else
        {
            playerFacingDirection = -1;
        }

      //  Instantiate(hitParticle, Slime.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));

        // one or the other should work and randomize the hit particle (make sure to un-comment the serializedfield HitParticle)
        Instantiate(HitParticle, aliveGO.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));
        Instantiate(HitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));

        if (playerFacingDirection == 1) {
            playerOnLeft = true;
        }
        else {
            playerOnLeft = false;
        }

             aliveAnim.SetBool("Attacked", true);
             StartCoroutine(Test());

        aliveAnim.SetBool("playerOnLeft", playerOnLeft);
        aliveAnim.SetTrigger("damage");

        if (applyKnockback && currentHealth > 0.0f) {
            Knockback();
        }

        if (currentHealth <= 0.0f) {
            Die();
        }
    }

    private void Knockback() {
        Debug.Log("Ok");
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
    }

    private void checkKnockback() {
        if (Time.time >= knockbackStart + knockbackDuration && knockback) {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }

    private void Die() {
       // aliveGO.SetActive(false);
        aliveAnim.SetBool("Broken", true);
       // Destroy(gameObject,0.95f);
       
     //  brokenTopGO.SetActive(true);
    StartCoroutine(Test2());



     //   brokenTopGO.transform.position = aliveGO.transform.position;
        heart.SetActive(true);
        heart.transform.position = aliveGO.transform.position;
        

       // rbBrokenBot.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
       // rbBrokenTop.velocity = new Vector2(knockbackDeathSpeedX * playerFacingDirection, knockbackDeathSpeedY);
      //  rbBrokenTop.AddTorque(deathTorque * -playerFacingDirection, ForceMode2D.Impulse);
     //     Destroy(gameObject,0.5f);
    }

/*
   
     void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("flag 2");
        }
    }
*/
  IEnumerator Test()
    {
        yield return new WaitForSeconds(0.2f);
        //  Debug.Log("Hi");
      //  anim.SetBool("setAttack", false);
         aliveAnim.SetBool("Attacked", false);
      //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }

    IEnumerator Test2()
    {
        yield return new WaitForSeconds(0.9f);
         // aliveAnim.SetBool("Broken", false);
        aliveGO.SetActive(false);
      

    }

    public void CollisionDetected(IncreaseHp childScript)
     {
         Debug.Log("child collided");
     } 


    
    
}


/*

     aliveAnim.SetBool("Attacked", true);
             StartCoroutine(Test());


 aliveAnim.SetBool("Broken", true);
             //StartCoroutine(Test2());
             Destroy(gameObject,0.9f);
             
    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.2f);
        //  Debug.Log("Hi");
      //  anim.SetBool("setAttack", false);
         aliveAnim.SetBool("Attacked", false);
      //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }

             */