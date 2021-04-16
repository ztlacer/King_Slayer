using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knight Player", menuName = "Stats/Player/Knight")]
public class PlayerKnightStat : StatObject
{

    public void Awake()
    {
        type = CharacterType.PlayerKnight;
    }
}
