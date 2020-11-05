using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : Entity
{

    public E8_IdleState idleState { get; private set; }
     public E8_RangedAttackState rangedAttackState {get; private set;}

      [SerializeField]
    private D_IdleState idelstateData;

    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform rangedAttackPosition;


     public override void Start()
    {
        base.Start();
          idleState = new E8_IdleState(this, stateMachine, "idle", idelstateData, this);
           rangedAttackState = new E8_RangedAttackState(this,stateMachine,"range", rangedAttackPosition,  rangedAttackStateData,this);
        stateMachine.Initialize(rangedAttackState );


    }

     public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
       

    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
 
        
        
        if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(rangedAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(idleState);
        }
       
}

}
