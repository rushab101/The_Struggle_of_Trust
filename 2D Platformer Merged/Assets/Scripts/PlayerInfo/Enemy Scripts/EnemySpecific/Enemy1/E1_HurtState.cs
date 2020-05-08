using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_HurtState : HurtState
{
    private Enemy1 enemy;
    protected bool done;
    protected float counter;
    public E1_HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Enemy1 enemy) : base(etity, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        counter = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        counter = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        counter++;
  
        if (hurting && counter > 25f)
        {

            //Debug.Log("VALUE IS");
              Debug.Log(counter);
          //  stateMachine.ChangeState(enemy.idleState);
           
        }
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
