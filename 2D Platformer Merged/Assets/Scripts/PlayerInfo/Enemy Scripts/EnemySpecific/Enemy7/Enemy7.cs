using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : Entity
{
     public E7_MoveState moveState { get; private set; }

     public E7_IdleState idleState { get; private set; }

      [SerializeField]
    private D_IdleState idelstateData;
    [SerializeField]
    private D_MoveState moveStateData;

     private Vector2 movement,
        touchDamageBotLeft,
        touchDamageTopRight;


      [SerializeField]
    private float
        lastTouchDamageTime, // last time the enemy damaged
        touchDamageCoolDown,
        touchDamage,
        touchDamageWidth,
        touchDamageHeight;

         [SerializeField]
    private Transform
     touchDamageCheck;

      [SerializeField]
    private LayerMask 
        whatisPlayer;

      public override void Start()
    {
        base.Start();
        moveState = new E7_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new  E7_IdleState(this, stateMachine, "idle", idelstateData, this);
        stateMachine.Initialize(moveState);
    }



   
}
