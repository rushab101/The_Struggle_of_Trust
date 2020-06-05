using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Entity
{
       public E4_MoveState moveState { get; private set; }
         public E4_IdleState idleState { get; private set; }
         
    public E4_DeadState deadState { get; private set; }
     public E4_HurtState hurtState  { get; private set; }

         
    [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;

    protected AttackDetails attackDetails;
      [SerializeField]
    private D_DeadState deadStateData;
     [SerializeField]
    private D_HurtState hurtStateData;

     
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
        moveState = new E4_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E4_IdleState(this, stateMachine, "idle", idelstateData, this);
         deadState = new E4_DeadState(this,stateMachine,"dead",deadStateData,this);
          hurtState = new E4_HurtState(this, stateMachine, "hurt", hurtStateData, this);
        stateMachine.Initialize(moveState);
    }

      public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
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
        SetVelocity(0f);
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
