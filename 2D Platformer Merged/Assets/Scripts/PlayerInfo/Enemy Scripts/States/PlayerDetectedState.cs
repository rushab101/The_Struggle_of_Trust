using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInminAgroRange;
    protected bool isPlayerinMAxAgroRange;
    public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
    isPlayerInminAgroRange=entity.CheckPlayerInMinAgroRange();
      isPlayerInminAgroRange=entity.CheckPlayerinMaxAgroRange();
    }

  
 

    public override void Exit()
    {
        

      
    }

    

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
         isPlayerInminAgroRange=entity.CheckPlayerInMinAgroRange();
      isPlayerInminAgroRange=entity.CheckPlayerinMaxAgroRange();
    }

   

  
}
