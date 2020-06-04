using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_DeadState : DeadState
{
  
  private Enemy3 enemy;
    public E3_DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Enemy3 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
  int count = Random.Range(3, 5); //100% Chance
  int random = Random.Range(1,4);
        
        for (int i = 0; i < count; ++i)
        {
            if (random >=2)
            {
                 GameObject.Instantiate(stateData.Green_coin, entity.aliveGO.transform.position, Quaternion.identity);
            }
            if (random== 1)
            {
                GameObject.Instantiate(stateData.Hearts, entity.aliveGO.transform.position, Quaternion.identity);
                break;
            }
           

        }


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
