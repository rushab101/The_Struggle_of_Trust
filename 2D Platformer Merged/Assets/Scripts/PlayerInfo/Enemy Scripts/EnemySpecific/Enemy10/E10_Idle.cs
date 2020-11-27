using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E10_Idle : IdleState
{
    
    private Enemy10 enemy;
    public E10_Idle(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy10 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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
        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
}
