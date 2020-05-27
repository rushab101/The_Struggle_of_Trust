using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
     public E3_MoveState moveState { get; private set; }
    public E3_idleState idleState { get; private set; }

    [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;


    
    public override void Start()
    {
        base.Start();
        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E3_idleState(this, stateMachine, "idle", idelstateData, this);
        stateMachine.Initialize(moveState);
    }


}
