using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour {

    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput;
    private bool isAttacking;
    private bool isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity; // Storing the last time player attempted to attack and will be ready to attack

    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
    }

    private void Update() {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput() { //Checks for any combat related input from the player
        //if (Input.GetKeyDown(KeyCode.V)) { // "V" is for attack
        if (Input.GetMouseButtonDown(0)) { // True if LMB/Mouse 1 is pressed
            if (combatEnabled) {
                Debug.Log("MB1 was pressed.");
                //Attempt to Combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void CheckAttacks() { // Makes attack happen when there is an input
        if (gotInput) {
            // Perform Attack 1
            if (!isAttacking) {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
            }
        }

        if (Time.time >= lastInputTime + inputTimer) {
            // Wait for new input
            gotInput = false;
        }
    }

    private void CheckAttackHitbox() { // Detect damagable objects in a range
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable); // Detect all objects in a circle

        foreach (Collider2D collider in detectedObjects) {
            collider.transform.parent.SendMessage("Damage", attack1Damage); // Used to call function on scripts on objects without knowing which script it is

        }
    }

    private void FinishAttack1() { // Called at end of attack animation, to let script know it's done
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
