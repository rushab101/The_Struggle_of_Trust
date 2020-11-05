using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8_IdleState : IdleState
{
       private Enemy8 enemy;
    public E8_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy8 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
         if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.rangedAttackState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
