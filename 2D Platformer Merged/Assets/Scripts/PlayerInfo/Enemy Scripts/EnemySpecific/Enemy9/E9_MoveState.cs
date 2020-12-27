using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9_MoveState : FlyMoveState
{
  
    private Enemy9 enemy;
    private int state = 0;
    private int attk_state = 0;
    private int mel_att_state = 0;
    private float x_pos;
    private float y_pos;
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
      
    
        //enemy.CheckTouchDamage();
       x_pos = entity.positionOfObject.x;
       y_pos = entity.positionOfObject.y;
       int x_att = 0;
       int y_att = 0;
       x_att = (int)x_pos;
       y_att = (int)y_pos;
     //  Debug.Log(entity.facingDirection);
       // Debug.Log(attk_state);
//        Debug.Log(y_att);
        if (y_att == -1 && mel_att_state == 0)
        {
          //  Debug.Log("Went into melee attack");
            stateMachine.ChangeState(enemy.meleeAttackState);
            mel_att_state = 1;
        }
        if (y_att == 12 && mel_att_state == 1)
        {
          //  Debug.Log("Went into melee attack");
            stateMachine.ChangeState(enemy.meleeAttackState);
            mel_att_state = 0;
        }
       if (x_att == -34 && attk_state == 0){
          
            stateMachine.ChangeState(enemy.rangedAttackState);
            attk_state = 1;
       }
      // if (x_att >= -40){
      //     attk_state = 0;
      // }
       if (x_att <= -25 && x_att >= -20){
           attk_state = 0;
       }

        if (x_att == -12 && attk_state == 1){
          
            stateMachine.ChangeState(enemy.rangedAttackState);
            attk_state = 2;
       }
     
        if (x_att == 8 && attk_state == 2){
          
            stateMachine.ChangeState(enemy.rangedAttackState);
            if (entity.facingDirection == 1)
            attk_state = 3;
            else 
                attk_state = 1;
       }
     

      // Debug.Log(state);
       if (isDetectingWall && state== 0)
       {
         //  Debug.Log("Flag1");
          // if (attk_state == 0)
          // {
            //   attk_state = 1;
                stateMachine.ChangeState(enemy.rangedAttackState);
          // }
           
        //    Debug.Log("Flag2");
           entity.SetVelocityUp(-5f);
          
           state = 1;
       }
       else if (isDetectingLedge && state== 1)
       {
            entity.Flip();
            attk_state = 0;
            entity.SetVelocityUp(-5f);
         //  entity.SetVelocityUp(5f);
           state = 2;
           
       }
        else if (isDetectingLedge2 && state ==2)
        {
             stateMachine.ChangeState(enemy.rangedAttackState);
           entity.SetVelocity(5f);
           state = 3;
          //  enemy.idleState.SetFlipAfterIdle(true);
            //    stateMachine.ChangeState(enemy.idleState);
        }
        else if (isDetectingWall && state == 3)
        {
             stateMachine.ChangeState(enemy.rangedAttackState);
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
            stateMachine.ChangeState(enemy.rangedAttackState);
            entity.SetVelocity(5f);
            if (entity.facingDirection ==1)
            state = 0;
            else state = 2;
           

       }
       else{
//         Debug.Log(state);
           if (state == 2)
           {
//                Debug.Log(isDetectingLedge2);
               entity.SetVelocityUp(-5f);
            
           } else if (state == 4)
           {
               
                entity.SetVelocityUp(5f);
               //to do
           } 
           else if (state == 1)
           {
               // entity.Flip();
              //  attk_state = 0;
                entity.SetVelocityUp(-5f);
           }
           else if (state == 5)
           {
             entity.SetVelocityUp(5f);
            
           }
           else if (state == 3)
           {
              entity.SetVelocity(-5f);
               // entity.SetVelocityUp(5f);
           }
           else{
  //             Debug.Log(state);
//                Debug.Log("Last Flag");
                entity.SetVelocity(-5f);

           }
              

       }
       
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }




}
