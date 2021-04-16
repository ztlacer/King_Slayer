using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pawn Player", menuName = "Stats/Player/Pawn")]
public class PlayerPawnStat : StatObject
{
    
    public void Awake()
    {
        type = CharacterType.PlayerPawn;
    }
}
