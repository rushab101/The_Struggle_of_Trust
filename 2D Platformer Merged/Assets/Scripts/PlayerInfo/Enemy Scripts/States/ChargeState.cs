using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    public ChargeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }

    public override void Enter()
    {
        base.Enter();
     
        entity.SetVelocity(stateData.chargeSpeed);
    }

   
   

    public override void Exit()
    {
        base.Exit();
    }

   

  
  

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
