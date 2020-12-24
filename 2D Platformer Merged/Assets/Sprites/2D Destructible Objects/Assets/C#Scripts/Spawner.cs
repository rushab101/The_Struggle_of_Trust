using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform whereToSpawn;

    public void Spawn()
    {
        if (isActiveAndEnabled && gameObject.activeSelf)
        {
            Instantiate(prefabToSpawn, whereToSpawn.position, Quaternion.identity);
        }
    }
}
