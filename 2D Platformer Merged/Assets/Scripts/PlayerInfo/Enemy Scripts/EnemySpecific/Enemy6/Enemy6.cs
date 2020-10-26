using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : Entity
{
    public E6_IdleState idleState { get; private set; }
    public E6_moveState moveState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;

    [SerializeField]
    private D_IdleState idelstateData;

    


    public override void Start()
    {
        base.Start();
        moveState = new E6_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E6_IdleState(this, stateMachine, "idle", idelstateData, this);
      
        //hurtState = new E5_HurtState(this, stateMachine, "hurt", this);
       
        stateMachine.Initialize(moveState);
    }


}
