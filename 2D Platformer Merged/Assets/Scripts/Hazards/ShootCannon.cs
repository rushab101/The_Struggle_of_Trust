using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    protected D_RangedAttackState stateData;
     public GameObject projectile;
   protected Projectile projectileScript;
    protected Transform attackPosition;
     private GameObject aliveGO;


    // Start is called before the first frame update
    void Start()
    {
         aliveGO = transform.Find("can").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
         
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed,stateData.projectileTravelDistance, stateData.projectileDamage);
       
    }

    // Update is called once per frame
    void Update()
    {
         Instantiate( projectile, aliveGO.transform.position,projectile.transform.rotation);
        
    }
}
