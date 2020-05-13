using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEPlayer : MonoBehaviour
{
   


    private float alpha;
    [SerializeField]
    private float alphaSet=0.8f;
    [SerializeField]
    private float alphaDecay = 10f;
    private SpriteRenderer playerSR;
    private Color color;
    private float canGetHit;
    private float totalHealth;
    private SpriteRenderer SR;
        private Transform player;

    
    private void OnEnable()
    {
        SR= GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();
        SR.sprite = playerSR.sprite;
      }

       private void Update()
    {
        alpha -=alphaDecay * Time.deltaTime;
         canGetHit = FindObjectOfType<PlayerController>().DamageOrNot();
        totalHealth = FindObjectOfType<PlayerStats>().Healths();
        if ( FindObjectOfType<PlayerCombatController>().animationIE && totalHealth > 1)
        {
             playerSR.color = new Color (1f,1f,1f,0.5f);
        }
        else if (canGetHit <= 20)
        {
             playerSR.color = new Color (1f,1f,1f,1f);//jj
        }
       
      
    }




}
