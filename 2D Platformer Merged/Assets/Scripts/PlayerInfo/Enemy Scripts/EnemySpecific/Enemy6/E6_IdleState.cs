using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_IdleState : IdleState
{
      private Enemy6 enemy;
    public E6_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy6 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
       // enemy.CheckTouchDamage();
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
