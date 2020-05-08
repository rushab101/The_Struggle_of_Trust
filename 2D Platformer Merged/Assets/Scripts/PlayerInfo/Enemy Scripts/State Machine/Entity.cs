using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public int facingDirection { get; private set;}
    public Rigidbody2D rb {get; private set;}
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public AniimationToStateMachine atsm {get; private set;}
    [SerializeField]
    private Transform wallCheck;
     [SerializeField]
    private Transform ledgeCheck;
      [SerializeField]
    private Transform playerCheck;


    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        facingDirection = 1;
        aliveGO = transform.Find("Slime").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        atsm = aliveGO.GetComponent<AniimationToStateMachine>();
    }
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace; //set the velocity of the enemy
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position,aliveGO.transform.right,entityData.wallCheckDistance,entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
   return Physics2D.Raycast(ledgeCheck.position,Vector2.down,entityData.ledgeCheckDistance,entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange() //Shorter Distance Check between Player and enemy
    {
        return Physics2D.Raycast(playerCheck.position,aliveGO.transform.right,entityData.minAgroDistance,entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerinMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position,aliveGO.transform.right,entityData.maxAgroDistance,entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position,aliveGO.transform.right,entityData.closeRangeActionDistance,entityData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *=-1;
        aliveGO.transform.Rotate(0f,180f,0f);
    }

   public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position,ledgeCheck.position + (Vector3)(Vector2.down *entityData.ledgeCheckDistance));
       
        
    }

}
