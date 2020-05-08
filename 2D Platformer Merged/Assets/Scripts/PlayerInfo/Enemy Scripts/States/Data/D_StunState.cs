using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="newStunStateData", menuName = "Data/State Data/Stun Data")]
public class D_StunState : ScriptableObject
{
   public float stunTime = 3f;
   public float stunKnockbackTime = 0.2f;
   public Vector2 stunKnockBackAngle;
   public float stunKnockBackSpeed = 20f;

}
