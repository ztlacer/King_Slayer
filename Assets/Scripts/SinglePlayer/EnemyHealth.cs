using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: Health
{
    void Start()
    {
        print(GetComponentInParent<EnemyKnightStat>().stats);
        ownStats = GetComponentInParent<EnemyKnightStat>().stats;
        print(ownStats);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damagingWeapon)
        {
            print("GotHit");
            int dmg = enemyStats.Attack * 2 - ownStats.Defense;
            ModifyHealth(-dmg);
        }

    }
}
