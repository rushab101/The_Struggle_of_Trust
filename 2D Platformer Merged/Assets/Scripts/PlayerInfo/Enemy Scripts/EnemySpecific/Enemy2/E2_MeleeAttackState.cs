using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MeleeAttackState :  MeleeAttackState
{
    private Enemy2 enemy;
    public E2_MeleeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy2 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy= enemy;
    }

     public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else 
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
}
