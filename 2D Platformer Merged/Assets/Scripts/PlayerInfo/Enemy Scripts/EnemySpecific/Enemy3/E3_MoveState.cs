using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_MoveState : MoveState
{
     private Enemy3 enemy;
     public float x; 
     public bool went_in;
     
     
    public E3_MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy3 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

     public override void Enter()
    {
        base.Enter();
      //  GameObject.Find("Slime").transform.position;
    }

   

    public override void Exit()
    {
        base.Exit();
    }

 
    public override void LogicUpdate()
    {
         base.LogicUpdate();
         /*
          if (isPlayerinMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
       */
       enemy.CheckTouchDamage();
       x = entity.positionOfObject.x;

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);    
        }
 
/*
       if (x > 50 && !went_in)
       {
           entity.Flip();
           went_in = true;
         stateMachine.ChangeState(enemy.moveState);
       }
*/

       else if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            went_in = false;
            stateMachine.ChangeState(enemy.idleState);
        }

      
        
    }

    


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
