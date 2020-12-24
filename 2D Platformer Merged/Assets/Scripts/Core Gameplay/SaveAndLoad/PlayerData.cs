using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   public float[] position;
   public PlayerData(float x, float y, float z)
   {
       position = new float[3];
       position[0] = x;
       position[1] = y;
       position[2] = z;
   }
}
