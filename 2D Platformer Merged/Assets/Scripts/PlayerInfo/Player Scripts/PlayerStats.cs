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
    private bool GameOver= false;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //   GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("GameManager").GetComponent<Respawn>();
    }

    
    void Update() {
        if (GameOver)
        {
            StartCoroutine(Test());
           // FindObjec.GameOver();
        }

    }

    
    public void Die()
    {
        Instantiate(deathChunckParticle, transform.position, deathChunckParticle.transform.rotation);
        Instantiate(deathChunckParticle, transform.position, deathBloodParticle.transform.rotation);
        FindObjectOfType<PlayerController>().canMove= false;
        FindObjectOfType<PlayerController>().canFlip = false;
        FindObjectOfType<PlayerController>().anim.SetBool("playerDead", true);
        GameOver = true;
     //   GM.RespawnIn();
       
        

    }

       IEnumerator Test()
    {
       // yield return new WaitForSeconds(0.5f);
       // FindObjectOfType<PlayerController>().anim.SetBool("playerDead", true);
        yield return new WaitForSeconds(1.0f);
         Destroy(gameObject);
       
    }

}
