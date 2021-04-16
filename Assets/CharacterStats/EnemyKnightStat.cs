using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knight Enemy", menuName = "Stats/Enemy/Knight")]
public class EnemyKnightStat : StatObject
{

    public void Awake()
    {
        type = CharacterType.EnemyKnight;
    }
}
