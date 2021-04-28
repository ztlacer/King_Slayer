using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: Health
{
    void Start()
    {
        ownStats = GetComponentInParent<EnemyKnightStat>().stats;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damagingWeapon)
        {
            int dmg = enemyStats.Attack * 2 - ownStats.Defense;
            ModifyHealth(-dmg);
        }

    }
}
