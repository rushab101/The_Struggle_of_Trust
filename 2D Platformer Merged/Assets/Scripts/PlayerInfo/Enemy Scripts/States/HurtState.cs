using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
    protected bool hurting;
    protected bool complete;
   
    public HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName) : base(etity, stateMachine, animBoolName) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {

        base.Enter();
     
    }


    public override void Exit() {
        base.Exit();
    }


    public override void LogicUpdate() {
        base.LogicUpdate();
          hurting = entity.PlayerDamaged;
         // entity.PlayerDamaged = false;

    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }

    

   
}
