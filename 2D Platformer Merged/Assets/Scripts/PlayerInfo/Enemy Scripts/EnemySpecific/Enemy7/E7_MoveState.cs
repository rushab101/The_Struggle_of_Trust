using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E7_MoveState : FlyMoveState
{
    private Enemy7 enemy;
    private float y_direction;
    public float setUpperBound;
     public float setLowerBound;
     protected float counter;
    bool went_in = false;
     
     
    public E7_MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy7 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

     public override void Enter()
    {
        base.Enter();
       // GameObject.Find("Slime").transform.localPosition;
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
          if (isPlayerinMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
       */
    //   enemy.CheckTouchDamage();
      
/*
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);    
        }
 */
/*
       if (x > 50 && !went_in)
       {
           entity.Flip();
           went_in = true;
         stateMachine.ChangeState(enemy.moveState);
       }
*/
y_direction= entity.positionOfObject.y;
   // Debug.Log(y_direction);
   

    /*
        if (y_direction > 7.17f && !went_in)
        {
           // enemy.idleState.SetFlipAfterIdle(true);
            went_in = true;;
            entity.Flip2();
            stateMachine.ChangeState(enemy.moveState);
        }
        else if (y_direction < -1.07 && went_in)
        {
            went_in = false;
             entity.Flip2();
            stateMachine.ChangeState(enemy.moveState);
        }
    */
   // Debug.Log(went_in);
     if (isDetectingLedge && went_in)
        {
            went_in = false;
             entity.Flip3();
            stateMachine.ChangeState(enemy.moveState);
        }
      else if (isDetectingLedge2 && !went_in)
        {
             went_in = true;;
            entity.Flip3();
            stateMachine.ChangeState(enemy.moveState);
        }

        

      
        
    }

    


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
