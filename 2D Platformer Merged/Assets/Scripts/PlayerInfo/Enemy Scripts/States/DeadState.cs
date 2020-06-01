﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;
    public bool dead_true=false;
    public DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public DeadState()
    {

    }




   

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        GameObject.Instantiate(stateData.deathBloodParticle,entity.aliveGO.transform.position,stateData.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deathChunkParticle,entity.aliveGO.transform.position,stateData.deathChunkParticle.transform.rotation);

       //  StartCoroutine(Test());
       //  RunCoroutine();
       dead_true= true;
        entity.gameObject.SetActive(false);
    }


     private void RunCoroutine()
     {
         Test2.t.GetComponent<Test2>()._StartCoroutine(enumerator());
     }
 
     public IEnumerator enumerator()
     {
         yield return new WaitForSeconds(0.35f);
          entity.gameObject.SetActive(false);
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
