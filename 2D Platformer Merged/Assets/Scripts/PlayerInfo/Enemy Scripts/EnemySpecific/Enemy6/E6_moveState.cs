using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_moveState : MoveState
{
    private Enemy6 enemy;
     public E6_moveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy6 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        entity.PlayMoveSound(); 
      


    if (isDetectingWall || !isDetectingLedge)
        {
             entity.Flip();
           // enemy.idleState.SetFlipAfterIdle(true);
    
            stateMachine.ChangeState(enemy.idleState);
        }

      
        
    }

    


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}



