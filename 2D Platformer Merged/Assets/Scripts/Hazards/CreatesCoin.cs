using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatesCoin : MonoBehaviour
{

       [SerializeField]
    private float maxHealth, knockbackSpeedX =10f, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque; 

    private int minCount = 3;
    private int maxCount = 10;

    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private GameObject HitParticle;
      [SerializeField]
    private GameObject GreenCoins;
      [SerializeField]
    private GameObject YellowCoins;
      [SerializeField]
    private GameObject BlueCoins;
    [SerializeField]
    private GameObject RedCoins;
    [SerializeField]
    private GameObject PurpleCoins;

    public AttackDetails attackDetails;

    private float currentHealth, knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback,done = false;

      private PlayerController pc;
    private GameObject aliveGO;
    private Rigidbody2D rbAlive;
    private Animator aliveAnim;

    private void Start() {
        currentHealth = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        aliveGO = transform.Find("Alive").gameObject; 
        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        aliveGO.SetActive(true);       
    }

    private void Update() {
        checkKnockback();
       
    }

    public void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
    

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
     //  Instantiate(HitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));

        if (playerFacingDirection == 1) {
            playerOnLeft = true;
        }
        else {
            playerOnLeft = false;
        }

             aliveAnim.SetBool("hit", true);
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
       
        aliveAnim.SetBool("broke", true);
   
    StartCoroutine(Test2());

        int count = Random.Range(minCount,maxCount); //100% Chance
        int blue_count = Random.Range(2,7);  //50% Chance
         int yellow_count = Random.Range(1,5);
         int red_count = Random.Range(0,1);

         

        for (int i = 0; i < count; ++i) {
              StartCoroutine(Test3());
        Instantiate(GreenCoins, aliveGO.transform.position,Quaternion.identity);
          
        }
     

        
    }


  IEnumerator Test()
    {
        yield return new WaitForSeconds(0.2f);
         aliveAnim.SetBool("hit", false);
    }

    

    IEnumerator Test2()
    {
        yield return new WaitForSeconds(0.9f);
        aliveGO.SetActive(false);
    }
     IEnumerator Test3()
    {
        yield return new WaitForSeconds(0.1f);
        aliveGO.SetActive(false);
    }

    
    
}
