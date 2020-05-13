/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void AddHealth()
    {
        PlayerStats.Instance.AddHealth();
    }

    public void Heal(float health)
    {
        PlayerStats.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        PlayerStats.Instance.TakeDamage(dmg);
    }
}
