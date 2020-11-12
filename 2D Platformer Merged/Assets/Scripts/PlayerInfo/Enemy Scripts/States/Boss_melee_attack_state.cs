using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_melee_attack_state : BossAttackState
{

 protected D_MeleeAttack stateData;
   protected AttackDetails attackDetails;

    public Boss_melee_attack_state(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
     
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

       
       
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    public override void TriggerAttack()
    {
        
        base.TriggerAttack();
    }
}