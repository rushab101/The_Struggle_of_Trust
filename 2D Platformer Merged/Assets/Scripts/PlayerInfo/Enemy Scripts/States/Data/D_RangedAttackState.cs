using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newRangedAttackStateData", menuName = "Data/State Data/Range Attack State Data")]
public class D_RangedAttackState :  ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance=3f;
  
}
