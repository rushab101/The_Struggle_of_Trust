using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMoveState : State
{
    protected D_MoveState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    
    protected bool isDetectingLedge2;

    protected bool isPlayerinMinAgroRange;
    protected bool performCloseRangeAction;

    public FlyMoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isDetectingLedge2 = entity.CheckUp();
        isPlayerinMinAgroRange = entity.CheckPlayerInMinAgroRange();
        performCloseRangeAction=entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityUp(stateData.movementSpeed);
        
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
