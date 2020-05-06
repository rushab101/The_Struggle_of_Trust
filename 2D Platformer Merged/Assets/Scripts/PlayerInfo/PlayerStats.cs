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





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    public void Die()
    {
        Instantiate(deathChunckParticle, transform.position, deathChunckParticle.transform.rotation);
        Instantiate(deathChunckParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
        

    }

}
