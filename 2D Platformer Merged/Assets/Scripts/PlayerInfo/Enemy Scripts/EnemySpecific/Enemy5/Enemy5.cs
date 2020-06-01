using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 :  Entity
{
    public E5_moveState moveState { get; private set; }
    public E5_IdleState idleState { get; private set; }
         
    public E5_DeadState deadState { get; private set; }
     public E5_HurtState hurtState  { get; private set; }

         
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
        moveState = new E5_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E5_IdleState(this, stateMachine, "idle", idelstateData, this);
         deadState = new E5_DeadState(this,stateMachine,"dead",deadStateData,this);
           hurtState = new E5_HurtState(this, stateMachine, "hurt", this);
       
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
       // CheckTouchDamage();
        
       moveStateData.movementSpeed+=10f;
         if (isDead)
        {
            moveStateData.movementSpeed=30f;
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
       if(FindObjectOfType<PlayerStats>().GameOver)
         {
             moveStateData.movementSpeed=30f;
         }

        if (Time.time >= lastTouchDamageTime + touchDamageCoolDown)
        {
            touchDamageBotLeft.Set(touchDamageCheck.position.x - (touchDamageWidth / 2), touchDamageCheck.position.y - (touchDamageHeight / 2));
            touchDamageTopRight.Set(touchDamageCheck.position.x + (touchDamageWidth / 2), touchDamageCheck.position.y + (touchDamageHeight / 2));

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
