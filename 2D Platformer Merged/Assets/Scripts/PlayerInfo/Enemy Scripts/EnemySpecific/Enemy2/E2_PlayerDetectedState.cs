using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetectedState :  PlayerDetectedState
{
  private Enemy2 enemy;
    public E2_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData,Enemy2 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



         if (performCloseRangeAction)
        {
            if (Time.time >= enemy.dodgeState.startTime +enemy.dodgeStateData.dodgeCooldown)
            {
                stateMachine.ChangeState(enemy.dodgeState);
            }
            else {
                stateMachine.ChangeState(enemy.meleeAttackState);   
            }

             
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.rangedAttackState);
        }
        else if (!isPlayerinMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

        
    }

    

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
