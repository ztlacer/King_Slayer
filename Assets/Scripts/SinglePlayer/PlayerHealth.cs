using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private void Start()
    {
        ownStats.Health = maxHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyStats = other.GetComponent<EnemyKnightStat>().stats;
        }
        if (other.gameObject.tag == damagingWeapon)
        {
            print("hit me");
            int dmg = enemyStats.Attack * 2 - ownStats.Defense;
            ModifyPlayerHealth(-dmg);
            ModifyHealth(-dmg);
        }

    }

    public void ModifyPlayerHealth(int amount)
    {
        ownStats.Health += amount;


    }
}
