using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9_MeleeAttack : Boss_melee_attack_state
{
    private Enemy9 enemy;
    int timer = 0;
    public E9_MeleeAttack (Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy9 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy= enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
    }

   

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
      //  Debug.Log(timer);
      enemy.CheckTouchDamage();
       if (isAnimationFinished)
        {   
            Debug.Log("Meelee Attack Complete");
            stateMachine.ChangeState(enemy.moveState);
        }
           
    //    timer++;
     
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

 
  
}
