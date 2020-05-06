using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private GameObject
        deathChunckParticle,
        deathBloodParticle;

    private int currentHealth;
    private Respawn GM;
   





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //   GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("GameManager").GetComponent<Respawn>();
    }

    
    public void Die()
    {
        Instantiate(deathChunckParticle, transform.position, deathChunckParticle.transform.rotation);
        Instantiate(deathChunckParticle, transform.position, deathBloodParticle.transform.rotation);
     //   GM.RespawnIn();
        Destroy(gameObject);
        

    }

}
