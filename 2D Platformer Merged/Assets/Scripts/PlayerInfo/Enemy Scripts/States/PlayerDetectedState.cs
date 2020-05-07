using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInminAgroRange;
    protected bool isPlayerinMaxAgroRange;
    public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInminAgroRange=entity.CheckPlayerInMinAgroRange();
     isPlayerinMaxAgroRange=entity.CheckPlayerinMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        
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
