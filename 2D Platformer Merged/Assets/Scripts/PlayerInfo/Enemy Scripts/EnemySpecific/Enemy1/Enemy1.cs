using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState {get; private set;}
    public E1_MoveState movestate {get; private set;}
    public E1_PlayerDetectedState playerDetectedState {get; private set;}

    [SerializeField]
    private D_IdleState idelstateData;
      [SerializeField]
    private D_MoveState moveStateData;
     [SerializeField]
    private D_PlayerDetected playerDetectedData;


    public override void Start()
    {
        base.Start();
        movestate = new E1_MoveState(this,stateMachine,"move",moveStateData,this);
        idleState = new E1_IdleState(this,stateMachine, "idle",idelstateData,this);
        playerDetectedState = new E1_PlayerDetectedState(this,stateMachine,"playerDetected",playerDetectedData,this);
        stateMachine.Initialize(movestate);

    }
   
}
