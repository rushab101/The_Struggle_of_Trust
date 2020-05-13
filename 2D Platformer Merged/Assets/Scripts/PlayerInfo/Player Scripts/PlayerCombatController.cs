﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class PlayerCombatController : MonoBehaviour
{

    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private float attack2Radius;
    [SerializeField]
    private float stunDamageAmount = 1f;
    [SerializeField]
    private Transform attack1HitBoxPos;
     [SerializeField]
    private Transform attack2HitBoxPos;
      [SerializeField]
    private Transform attack3HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;

    public bool gotInput;
    public bool animationIE;
    private float animationTimer;
    public bool airAttack;
    private bool isAttacking;
    private bool isFirstAttack;
    private float canGetHit;
    public bool down_attack;
    private bool is_attacking;
    public bool DoNotDamage=false;



    public float fJumpPressedRemember = 0;
    public float fJumpPressedRememberTime = 1.0f;




    private float lastInputTime = Mathf.NegativeInfinity; // Storing the last time player attempted to attack and will be ready to attack
    private AttackDetails attackDetails;

    private Animator anim;
    private PlayerController PC;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }
    public bool airChecker()
    {
        return airAttack;
    }

    private void CheckCombatInput()
    { //Checks for any combat related input from the player
        /*
           fJumpPressedRemember -= Time.deltaTime; //Dreacsing 
            if (Input.GetButtonDown("Jump"))
            {
             fJumpPressedRemember = fJumpPressedRememberTime;

                if (fJumpPressedRemember > 0 )
                {
                           Debug.Log("Test.");
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                           Debug.Log("Test 2");
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {

                           Debug.Log("Test 3");
                    }
                    fJumpPressedRemember = 0;
                }
                else
                {
                     Debug.Log("Test 4");
                }



            }
           */


        if (Input.GetKey(KeyCode.DownArrow) && !FindObjectOfType<PlayerController>().isGrounded)
        {
            if(combatEnabled &&(Input.GetKeyDown(KeyCode.Z) || ( Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z) ) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z) && Input.GetKeyDown(KeyCode.Space) ) ) ) 
            {
               down_attack = true;
            
               airAttack = false;
               gotInput = false;
            }
            else {
                down_attack = false;
            }

        }

       else if (Input.GetKeyDown(KeyCode.Z) && !FindObjectOfType<PlayerController>().isGrounded && !down_attack)
        {
            if (combatEnabled && !Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Up Attack.");
                gotInput = false;
                airAttack = true;
                lastInputTime = Time.time;
                // animationTimer = 0;


            }

        }
       

        //if (Input.GetKeyDown(KeyCode.V)) { // "V" is for attack
        if (Input.GetMouseButtonDown(0) ||  Input.GetKeyDown(KeyCode.Z) && FindObjectOfType<PlayerController>().isGrounded && !airAttack && !down_attack)
        { // True if LMB/Mouse 1 is pressed
            if (combatEnabled)
            {
                FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 0) * 0;
                //Attempt to Combat
                gotInput = true;
                airAttack = false;
                lastInputTime = Time.time;
            }



        }

    }

    private void CheckAttacks()
    { // Makes attack happen when there is an input
        if (gotInput)
        { //ground attack
            
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);

                // play random animation (07 may 2020)
                int index = UnityEngine.Random.Range(1, 4); // random number 
                FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 0);
                anim.Play("Attack" + index);
                Invoke("ResetAttack", .15f);
                FindObjectOfType<PlayerController>().isWalking = true;
            }
        }
        else if (airAttack) //air up attack
        { 

            animationTimer++;

            if (!isAttacking)
            {
                isAttacking = true;
                airAttack = false;
                anim.SetBool("attack1", true);
                isFirstAttack = !isFirstAttack;
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
                anim.SetBool("setAttack", true);
                int index = UnityEngine.Random.Range(1, 3); // random number 
                anim.Play("AirAttack" + index);
                Invoke("ResetAttack", .15f);
                StartCoroutine(Test());

            }

        }
        else if (down_attack) //air down attack
        {
            if (!isAttacking)
            {
                   // Debug.Log("Down attack.");
                isAttacking = true;
                down_attack = false;
                anim.SetBool("attack1", true);
                isFirstAttack = !isFirstAttack;
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
                anim.SetBool("downAttack", true);
                //int index = UnityEngine.Random.Range(1, 2); // random number 
                anim.Play("AirAttack3");
                Invoke("ResetAttack", .15f);
                StartCoroutine(Test2());

            }

        }





        if (Time.time >= lastInputTime + inputTimer)
        {
            // Wait for new input
            gotInput = false;
            airAttack = false;

        }







    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.35f);
        //  Debug.Log("Hi");
        anim.SetBool("setAttack", false);
      //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }

        IEnumerator Test2()
    {
        yield return new WaitForSeconds(0.42f);
        //  Debug.Log("Hi");
      //  anim.SetBool("setAttack", false);
        anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }

    //07 may 2020 (for rng attack anim)
    private void ResetAttack()
    {
        isAttacking = false;
    }

    private void CheckAttackHitbox()
    { // Detect damagable objects in a range
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable); // Detect all objects in a circle

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;



        foreach (Collider2D collider in detectedObjects)
        {
             DoNotDamage = true;
            collider.transform.parent.SendMessage("Damage", attackDetails); // Used to call function on scripts on objects without knowing which script it is

        }
          DoNotDamage = false;
    }

    
    private void CheckAttackHitbox2()
    { // Detect damagable objects in a range
        Collider2D[] detectedObjects2 = Physics2D.OverlapCircleAll(attack2HitBoxPos.position, attack2Radius, whatIsDamageable); // Detect all objects in a circle

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;



        foreach (Collider2D collider in detectedObjects2)
        {
            FindObjectOfType<Spikes>().OnCollisionEnter2D(collider);
            FindObjectOfType<PlayerController>().rb.velocity = new Vector2(0, 20);
                DoNotDamage = true;
            collider.transform.parent.SendMessage("Damage", attackDetails); // Used to call function on scripts on objects without knowing which script it is

        }
        DoNotDamage = false;
    }

       private void CheckAttackHitbox3()
    { // Detect damagable objects in a range
        Collider2D[] detectedObjects3 = Physics2D.OverlapCircleAll(attack3HitBoxPos.position, attack1Radius, whatIsDamageable); // Detect all objects in a circle

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;



        foreach (Collider2D collider in detectedObjects3)
        {
             DoNotDamage = true;
            collider.transform.parent.SendMessage("Damage", attackDetails); // Used to call function on scripts on objects without knowing which script it is

        }
          DoNotDamage = false;
    }

    private void FinishAttack1()
    { // Called at end of attack animation, to let script know it's done
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void Damage(AttackDetails attackDetails)
    {
        int direction;
        //Damage our player
        //PS.DecreaseHealth(attackDetails.damageAmount); // TODO: 
        canGetHit = FindObjectOfType<PlayerController>().DamageOrNot();
        UnityEngine.Debug.Log(canGetHit);


        if (canGetHit <= 20)
        {
           // animationIE = false;
            FindObjectOfType<PlayerStats>().TakeDamage(1f);
        }
      
        // 


        if (attackDetails.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        PC.knockBack(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
        Gizmos.DrawWireSphere(attack2HitBoxPos.position, attack2Radius);
        Gizmos.DrawWireSphere(attack3HitBoxPos.position, attack1Radius);
    }
}
