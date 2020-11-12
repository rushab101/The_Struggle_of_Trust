using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangeAttackState : BossAttackState
{

protected D_RangedAttackState stateData;
   protected AttackDetails attackDetails;
   protected GameObject projectile;
   protected Projectile projectileScript;
   Vector2 startPoint;
   float radius = 5f;
   float moveSpeed=5f;
   int temp = 0;

    public BossRangeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData) : base(etity, stateMachine, animBoolName, attackPosition)
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
        radius = 100f;
        temp = 0;
     
    }

    

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

   
    public override void LogicUpdate()
    {
        base.LogicUpdate();
//          Debug.Log("Went into trigger");
          if (temp ==0){
               SpawnProjectiles2(12);
               temp++;
          }
         
       
       
    }

  
    void SpawnProjectiles2(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;
        startPoint.x = attackPosition.position.x;
        startPoint.y = attackPosition.position.y;
//        Debug.Log(startPoint.x);
  //      Debug.Log(startPoint.y);
		for (int i = 0; i <= numberOfProjectiles - 1; i++) {
		
    
			float projectileDirXposition = startPoint.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = GameObject.Instantiate (stateData.projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
          
		}
	}



    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    public override void TriggerAttack()
    {
        
        base.TriggerAttack();
        Debug.Log("Went into trigger");
        projectile = GameObject.Instantiate(stateData.projectile,-attackPosition.position,attackPosition.rotation);
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed,stateData.projectileTravelDistance, stateData.projectileDamage);
       
    }
}