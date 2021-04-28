using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnightZone4Stats : MonoBehaviour
{
    public StatObject stats;

    public void Awake()
    {
        stats = new StatObject();
        stats.Stealth = 20;
        stats.Attack = 50;
        stats.Health = 100;
        stats.Defense = 50;
    }
}
