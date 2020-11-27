using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E10_move : MoveState
{
     private Enemy10 enemy;
     public float x; 
     public bool went_in;
     
     
    public E10_move(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy10 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
         
       enemy.CheckTouchDamage();
       x = entity.positionOfObject.x;

        if (entity.CheckPlayerinMaxAgroRange())
        {
            stateMachine.ChangeState(enemy.attackState);
        }
 


        if (isDetectingWall || !isDetectingLedge)
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
