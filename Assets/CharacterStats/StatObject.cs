using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    PlayerPawn = 0,
    EnemyPawn = 1,
    PlayerKnight = 2,
    EnemyKnight = 3
}

public class StatObject : ScriptableObject
{
    public CharacterType type;
    public int Stealth;
    public int Attack;
    public int Health;
    public int Defense;
}
