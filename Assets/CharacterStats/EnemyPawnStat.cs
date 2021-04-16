using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pawn Enemy", menuName = "Stats/Enemy/Pawn")]
public class EnemyPawnStat : StatObject
{

    public void Awake()
    {
        type = CharacterType.EnemyPawn;
    }
}
