using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knight Enemy", menuName = "Stats/Enemy/Knight")]
public class EnemyKnightStat : StatObject
{

    public void Awake()
    {
        Stealth = 20;
        Attack = 20;
        Health = 20;
        Defense = 20;
    }
}
