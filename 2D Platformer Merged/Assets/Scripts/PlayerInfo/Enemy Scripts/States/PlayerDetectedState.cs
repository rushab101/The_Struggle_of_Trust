using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInminAgroRange;
    protected bool isPlayerinMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInminAgroRange=entity.CheckPlayerInMinAgroRange();
     isPlayerinMaxAgroRange=entity.CheckPlayerinMaxAgroRange();
     performCloseRangeAction=entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
         performLongRangeAction= false;
        entity.SetVelocity(0f);
       
    }

   

   
    public override void Exit()
    {
        base.Exit();
    }

 

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >=startTime + stateData.actionTime)
        {
            performLongRangeAction = true;
        }
    }

   
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       
    }

   
  
}
