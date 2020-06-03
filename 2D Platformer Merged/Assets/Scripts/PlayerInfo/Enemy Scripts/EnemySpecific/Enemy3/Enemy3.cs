using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
     public E3_MoveState moveState { get; private set; }
    public E3_idleState idleState { get; private set; }
    
    public E3_EnemyAttackState meleeAttackState { get; private set; }


    public E3_DeadState deadState { get; private set; }
    public E3_HurtState hurtState  { get; private set; }



    [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;

      [SerializeField]
    private Transform meleeAttackPosition;

      [SerializeField]
    private Transform rangedAttackPosition;

        [SerializeField]
    private D_MeleeAttack meleeAttackStateData;

    [SerializeField]
    private D_DeadState deadStateData;

       [SerializeField]
    private D_HurtState hurtStateData;


  protected AttackDetails attackDetails;

     
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



    public override void Start()
    {
        base.Start();
        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E3_idleState(this, stateMachine, "idle", idelstateData, this);
        meleeAttackState = new E3_EnemyAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        deadState = new E3_DeadState(this,stateMachine,"dead",deadStateData,this);
        hurtState = new E3_HurtState(this, stateMachine, "hurt", this);
        stateMachine.Initialize(moveState);
    }

      public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        Vector2 botLeft = new Vector2(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
        Vector2 botRight= new Vector2(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2)); 
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
       // CheckTouchDamage();
         if (isDead)
        {
          stateMachine.ChangeState(deadState);
        }
        else if (PlayerDamaged && stateMachine.currentState != hurtState)
        {
            stateMachine.ChangeState(hurtState);
        }
 
    }

    
  public void CheckTouchDamage()
    {
      
     // Debug.Log("Checking");
            touchDamageBotLeft.Set(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
            touchDamageTopRight.Set(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));
 if (Time.time >= lastTouchDamageTime + touchDamageCoolDown){
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
