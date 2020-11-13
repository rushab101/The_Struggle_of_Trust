using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : Entity
{
    // Start is called before the first frame update
    public E9_MoveState moveState { get; private set; }
    public E9_RangeAttackState rangedAttackState { get; private set; }
    public E9_MeleeAttack meleeAttackState { get; private set; }

         public E9_HurtAttackState hurtState  { get; private set; }
         public E9_DeadState deadState { get; private set; }
    protected AttackDetails attackDetails;

    [SerializeField]
    private D_MoveState moveStateData;

     [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform rangedAttackPosition;

    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

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
        moveState = new E9_MoveState(this, stateMachine, "move", moveStateData, this);
        rangedAttackState = new E9_RangeAttackState(this, stateMachine, "range", rangedAttackPosition, rangedAttackStateData, this);
        meleeAttackState = new E9_MeleeAttack(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        hurtState = new E9_HurtAttackState(this, stateMachine, "hurt", hurtStateData, this);
        deadState = new E9_DeadState(this,stateMachine,"dead",deadStateData,this);


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
         Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);

    }
    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
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
