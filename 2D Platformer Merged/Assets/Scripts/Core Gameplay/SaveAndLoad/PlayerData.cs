using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   public float[] position;
   public PlayerData(float x, float y)
   {
       position = new float[2];
       position[0] = x;
       position[1] = y;
   }
}
