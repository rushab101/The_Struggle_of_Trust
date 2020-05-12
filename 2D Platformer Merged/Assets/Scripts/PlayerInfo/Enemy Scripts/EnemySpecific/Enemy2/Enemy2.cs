using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public E2_MoveState moveState { get; private set; }
    public E2_IdleState idleState { get; private set; }
    public E2_PlayerDetectedState playerDetectedState { get; private set; }
     public E2_LookForPlayerState lookForPlayerState { get; private set; }
       public E2_StunState stunState { get; private set; }
       public E2_ChargeState chargeState { get; private set; }
       
    public E2_DeadState deadState { get; private set; }


    public E2_MeleeAttackState meleeAttackState { get; private set; }

    public E2_DodgeState dodgeState {get; private set;}

    [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;

    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;

     [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
      [SerializeField]
    private D_ChargeState chargeStateData;
        [SerializeField]
    private D_DeadState deadStateData;
      [SerializeField]
    public D_DodgeState dodgeStateData;



    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_IdleState(this, stateMachine, "idle", idelstateData, this);
        playerDetectedState = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        meleeAttackState = new E2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
       // chargeState = new E2_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
           deadState = new E2_DeadState(this,stateMachine,"dead",deadStateData,this);
           stunState = new E2_StunState(this, stateMachine, "stun", stunStateData, this);
           dodgeState = new E2_DodgeState(this,stateMachine,"dodge",dodgeStateData,this);
        stateMachine.Initialize(moveState);


    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);

    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
 
        
         if (isDead)
        {
          stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }




}
