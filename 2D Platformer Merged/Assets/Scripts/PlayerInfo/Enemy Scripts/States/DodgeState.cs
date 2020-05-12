using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    protected D_DodgeState stateData;
    public DodgeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DodgeState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

       public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
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
