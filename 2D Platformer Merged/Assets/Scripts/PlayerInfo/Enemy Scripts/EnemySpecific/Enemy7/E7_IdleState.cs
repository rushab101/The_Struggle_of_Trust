using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E7_IdleState : IdleFlyState
{
     private Enemy7 enemy;
     public E7_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy7 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        /*
         if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        */
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

