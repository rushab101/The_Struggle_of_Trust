using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_EnemyAttackState : MeleeAttackState
{

     private Enemy3 enemy;
    public E3_EnemyAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy3 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy= enemy;
    }

     public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
                stateMachine.ChangeState(enemy.idleState);
        }
    }
}
