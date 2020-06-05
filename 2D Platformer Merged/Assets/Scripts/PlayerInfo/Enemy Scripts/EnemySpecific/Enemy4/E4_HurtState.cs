using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_HurtState : HurtState
{
   private Enemy4 enemy;
    protected bool done;
    
    Color done_default;
    protected float counter;
   
    public E4_HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HurtState stateData, Enemy4 enemy) : base(etity, stateMachine, animBoolName)
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
        done_default = new Color (255,255,255);
        
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
   entity.aliveGO.GetComponent<SpriteRenderer>().color = Color.red;
        if (counter > 25f)
        {

            //Debug.Log("VALUE IS");
              Debug.Log(counter);
          entity.aliveGO.GetComponent<SpriteRenderer>().color=done_default;
              stateMachine.ChangeState(enemy.moveState );
           
        }
       //  
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
