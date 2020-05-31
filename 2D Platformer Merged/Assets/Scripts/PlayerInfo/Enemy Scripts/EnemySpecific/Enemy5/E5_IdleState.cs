using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_IdleState : IdleState
{
     private Enemy5 enemy;
    public E5_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        enemy.CheckTouchDamage();
        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState );
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
