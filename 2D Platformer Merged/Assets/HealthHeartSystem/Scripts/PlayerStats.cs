using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    private bool GameOver= false;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    void Awake()
    {

        health = PlayerPrefs.GetFloat("Health");
        if (health ==0)
        {
            health = MaxHealth;
        }
    }


    public void TakeDamage(float dmg)
    {
         if (!FindObjectOfType<PlayerCombatController>().DoNotDamage)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            health -= dmg;
        }
         ClampHealth();
       //  UnityEngine.Debug.Log(health);

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            UnityEngine.Debug.Log("Death");
                GameOver = true;
            //PlayerisDead
           
            FindObjectOfType<PlayerStat>().Die();
            //StartCoroutine(Test());
           // FindObjectOfType<PlayerController>().GameOver();

        }

       
    }

    public float Healths()
    {

        return health;
    }

     public void SaveSettings()
    {

        PlayerPrefs.SetFloat("Health", health);
       // PlayerPrefs.Save();
    }



     void Update() {

              PlayerPrefs.SetFloat("Health", health);
        if (GameOver)
        {
            StartCoroutine(Test());
           // FindObjec.GameOver();
        }

    }


    void OnApplicationQuit()
    {
        health = MaxHealth;
        SaveSettings();

    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

       IEnumerator Test()
    {
        yield return new WaitForSeconds(1.5f);
      //  Debug.Log("Hi");
        SceneManager.LoadScene("Game Over");
       
    }
}
