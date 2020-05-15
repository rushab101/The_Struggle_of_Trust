using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pots : MonoBehaviour
{

       [SerializeField]
    private float maxHealth, knockbackSpeedX =10f, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque; 
    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private GameObject HitParticle;

    private float currentHealth, knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback,done = false;

      private PlayerController pc;
    private GameObject aliveGO, brokenTopGO, brokenBotGO ;
    private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
    private Animator aliveAnim;

    private void Start() {
        currentHealth = maxHealth;

        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGO = transform.Find("Alive").gameObject; 

        //brokenTopGO = Find("Hearts").gameObject; 
    
        brokenBotGO = transform.Find("Broken Bottom").gameObject;
        //Debug.Log(aliveGO);
      //  Instantiate(heart);
        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        rbBrokenTop = brokenTopGO.GetComponent<Rigidbody2D>();
        rbBrokenBot = brokenBotGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
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
   brokenBotGO.SetActive(true);
   brokenBotGO.transform.position = aliveGO.transform.position;
  // pc.transform.position = aliveGO.transform.position;
    
   
   // StartCoroutine(Test3());
if (Vector2.Distance(pc.transform.position,brokenBotGO.transform.position) <=2)
       {
            Debug.Log("flag 2");
            // FindObjectOfType<PlayerStats>().Heal(1f);
              StartCoroutine(Test3());
          
       }

       
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           


     //   brokenTopGO.transform.position = aliveGO.transform.position;
       // heart.SetActive(true);
       // heart.transform.position = aliveGO.transform.position;

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

    
  IEnumerator Test3()
    {
        yield return new WaitForSeconds(0.55f);
         FindObjectOfType<PlayerStats>().Heal(1f);
       Destroy(gameObject);
         
        //  Debug.Log("Hi");
      //  anim.SetBool("setAttack", false);
        
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
 void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
             FindObjectOfType<PlayerStats>().TakeDamage(1f);
           // UnityEngine.Debug.Log("Health-- TRUE (Spikes)");
           
            FindObjectOfType<PlayerController>().knockBack(FindObjectOfType<PlayerController>().GetFacingDirection());
        }
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