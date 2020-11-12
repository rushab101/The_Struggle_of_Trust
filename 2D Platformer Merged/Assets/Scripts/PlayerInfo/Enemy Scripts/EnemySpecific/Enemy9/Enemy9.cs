using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : Entity
{
    // Start is called before the first frame update
      public E9_MoveState moveState { get; private set; }
       public E9_RangeAttackState rangedAttackState {get; private set;}
        [SerializeField]
    private D_MoveState moveStateData;

    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

      [SerializeField]
    private Transform rangedAttackPosition;


    
    public override void Start()
    {
        base.Start();
        moveState = new E9_MoveState(this, stateMachine, "move", moveStateData, this);
        rangedAttackState = new E9_RangeAttackState(this,stateMachine,"range", rangedAttackPosition,  rangedAttackStateData,this);
       
        stateMachine.Initialize(moveState);
    }

      public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
 
    }



  
}
