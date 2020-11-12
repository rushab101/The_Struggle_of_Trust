using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : State
{
    protected Transform attackPosition;
    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;
    private int timer = 0;

    public BossAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(etity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
       
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
        entity.atsm.bossAttackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
    }

  

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        timer++;
         entity.SetVelocity(0f);
       // Debug.Log(timer);
        if (timer == 100)
        {
            isAnimationFinished = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public virtual void TriggerAttack()
    {

    }
    public virtual void FinishAttack()
    {
     //   isAnimationFinished= true;
    }

}