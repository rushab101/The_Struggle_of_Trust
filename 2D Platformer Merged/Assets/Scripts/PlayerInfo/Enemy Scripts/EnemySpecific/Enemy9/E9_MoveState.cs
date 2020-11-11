using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9_MoveState : FlyMoveState
{
  
    private Enemy9 enemy;
    private int state = 0;
    public E9_MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy9 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
      
          if (isPlayerinMinAgroRange)
        {
           // stateMachine.ChangeState(enemy.playerDetectedState);
        }
      
       Debug.Log(state);
       if (isDetectingWall && state== 0)
       {
           entity.SetVelocityUp(-5f);
          
           state = 1;
       }
       else if (isDetectingLedge && state== 1)
       {
            entity.Flip();
            entity.SetVelocityUp(-5f);
         //  entity.SetVelocityUp(5f);
           state = 2;
           
       }
        else if (isDetectingLedge2 && state ==2)
        {
           entity.SetVelocity(5f);
           state = 3;
          //  enemy.idleState.SetFlipAfterIdle(true);
            //    stateMachine.ChangeState(enemy.idleState);
        }
        else if (isDetectingWall && state == 3)
        {
            entity.SetVelocityUp(5f);
            state = 4;
        }
         else if (isDetectingLedge && state== 4)
       {
           entity.Flip();
           entity.SetVelocityUp(5f);
           state = 5;
       }
       else if (isDetectingLedge2 && state==5)
       {
            entity.SetVelocity(5f);
            state = 0;
           

       }
       else{
           if (state == 2)
           {
                Debug.Log(isDetectingLedge2);
               entity.SetVelocityUp(-5f);
            
           } else if (state == 4)
           {
               Debug.Log("Here");
                entity.SetVelocityUp(5f);
               //to do
           } else
                entity.SetVelocity(-5f);

       }
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }




}
