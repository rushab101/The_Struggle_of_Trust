using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : State
{
    protected D_DeadState stateData;
    public GameObject clone;
    public bool dead_true=false;
    private float counter = 0f;




    
    public BossDeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(etity, stateMachine, animBoolName)
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
        GameObject.Instantiate(stateData.deathBloodParticle,entity.aliveGO.transform.position,stateData.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deathChunkParticle,entity.aliveGO.transform.position,stateData.deathChunkParticle.transform.rotation);
        GameObject.Instantiate(stateData.HeartContainer,entity.aliveGO.transform.position,stateData.HeartContainer.transform.rotation);
        GameObject.Instantiate(stateData.Purple_coin,entity.aliveGO.transform.position,stateData.Purple_coin.transform.rotation);
        GameObject.Instantiate(stateData.Purple_coin,entity.aliveGO.transform.position,stateData.Purple_coin.transform.rotation);
        GameObject.Instantiate(stateData.Purple_coin,entity.aliveGO.transform.position,stateData.Purple_coin.transform.rotation);
        GameObject.Instantiate(stateData.Red_coin,entity.aliveGO.transform.position,stateData.Red_coin.transform.rotation);
        GameObject.Instantiate(stateData.Red_coin,entity.aliveGO.transform.position,stateData.Red_coin.transform.rotation);
        GameObject.Instantiate(stateData.Red_coin,entity.aliveGO.transform.position,stateData.Red_coin.transform.rotation);
        GameObject.Instantiate(stateData.Red_coin,entity.aliveGO.transform.position,stateData.Red_coin.transform.rotation);
        GameObject.Instantiate(stateData.Red_coin,entity.aliveGO.transform.position,stateData.Red_coin.transform.rotation);
        GameObject.Instantiate(stateData.Yellow_coin,entity.aliveGO.transform.position,stateData.Yellow_coin.transform.rotation);
        GameObject.Instantiate(stateData.Yellow_coin,entity.aliveGO.transform.position,stateData.Yellow_coin.transform.rotation);
        GameObject.Instantiate(stateData.Yellow_coin,entity.aliveGO.transform.position,stateData.Yellow_coin.transform.rotation);
         

       //  StartCoroutine(Test());
        dead_true= true;
        entity.gameObject.SetActive(false);
       //  RunCoroutine();
      
    }


     private void RunCoroutine()
     {
         Test2.t.GetComponent<Test2>()._StartCoroutine(enumerator());
     }
 
     public IEnumerator enumerator()
     {
         yield return new WaitForSeconds(10f);
         clone.SetActive(false);
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
