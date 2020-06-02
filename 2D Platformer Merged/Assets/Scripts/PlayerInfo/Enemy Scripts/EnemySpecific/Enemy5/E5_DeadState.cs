using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_DeadState :DeadState
{
     private Enemy5 enemy;
    public E5_DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        clone = (GameObject)GameObject.Instantiate(stateData.Explosion,entity.aliveGO.transform.position,stateData.Explosion.transform.rotation);
    }

    public override void Exit()
    {
        base.Exit();
     

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
