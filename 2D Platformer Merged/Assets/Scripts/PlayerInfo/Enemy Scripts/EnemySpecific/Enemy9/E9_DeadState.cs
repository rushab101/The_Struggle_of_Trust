using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9_DeadState  : BossDeadState
{
     private Enemy9 enemy;
     int counter = 0;
    public E9_DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Enemy9 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        if (counter == 10)
        clone.SetActive(false);
        counter++;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
