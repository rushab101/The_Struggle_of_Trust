using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy10 : Entity
{
    public E10_move moveState { get; private set; }
    public E10_Idle idleState { get; private set; }
    public E10_hurt hurtState { get; private set; }
    public E10_attack attackState { get; private set; }
    public E10_dead deadState { get; private set; }

    [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;


    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform rangedAttackPosition;


    private Vector2 movement,
        touchDamageBotLeft,
        touchDamageTopRight;


    [SerializeField]
    private float
      lastTouchDamageTime, // last time the enemy damaged
      touchDamageCoolDown,
      touchDamage,
      touchDamageWidth,
      touchDamageHeight;

    [SerializeField]
    private Transform
touchDamageCheck;

    [SerializeField]
    private LayerMask
     whatisPlayer;

    
  protected AttackDetails attackDetails;


    public override void Start()
    {
        base.Start();
        moveState = new E10_move(this, stateMachine, "move", moveStateData, this);
        idleState = new E10_Idle(this, stateMachine, "idle", idelstateData, this);
        deadState = new E10_dead(this, stateMachine, "dead", deadStateData, this);
        attackState = new E10_attack(this, stateMachine, "attack", rangedAttackPosition, rangedAttackStateData, this);
        hurtState = new E10_hurt(this, stateMachine, "hurt", this);
        stateMachine.Initialize(moveState);
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Vector2 botLeft = new Vector2(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
        Vector2 botRight = new Vector2(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
        Vector2 topRight = new Vector2(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));
        Vector2 topLeft = new Vector2(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));
        Gizmos.DrawLine(botLeft, botRight);
        Gizmos.DrawLine(botRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, botLeft);


    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);


        if (isDead)
        {
            PlayDeadSound();
            stateMachine.ChangeState(deadState);
        }
         else if (PlayerDamaged && stateMachine.currentState != hurtState)
        {
            PlayHitSound();
          //  FindObjectOfType<AudioManager>().Play("SlimeHit"); // 06 June 2020
            stateMachine.ChangeState(hurtState);
        }
       
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(attackState);
        }
         else if (!CheckPlayerInMinAgroRange())
        {
           Flip();
        }
    }



    public void CheckTouchDamage()
    {

        // Debug.Log("Checking");
        touchDamageBotLeft.Set(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
        touchDamageTopRight.Set(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));

        if (Time.time >= lastTouchDamageTime + touchDamageCoolDown)
        {


            if (Time.time >= lastTouchDamageTime + touchDamageCoolDown)
            {
                Collider2D hit = Physics2D.OverlapArea(touchDamageBotLeft, touchDamageTopRight, whatisPlayer);
                if (hit != null)
                {

                    lastTouchDamageTime = Time.time;

                    hit.SendMessage("Damage", attackDetails);
                    FindObjectOfType<TimeStop>().StopTime(0.25f, 10, 0.1f);
                }

            }
        }

    }


}
