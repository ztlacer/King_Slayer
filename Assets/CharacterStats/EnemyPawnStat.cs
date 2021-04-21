using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pawn Enemy", menuName = "Stats/Enemy/Pawn")]
public class EnemyPawnStat : StatObject
{

    public void Awake()
    {
        Stealth = 20;
        Attack = 20;
        Health = 20;
        Defense = 20;
    }
}
