using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : Entity
{
    // Start is called before the first frame update
      public E9_MoveState moveState { get; private set; }
        [SerializeField]
    private D_MoveState moveStateData;

    
    public override void Start()
    {
        base.Start();
        moveState = new E9_MoveState(this, stateMachine, "move", moveStateData, this);
       
        stateMachine.Initialize(moveState);
    }


  
}
