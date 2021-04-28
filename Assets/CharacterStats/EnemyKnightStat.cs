using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnightStat : MonoBehaviour
{
    public StatObject stats;

    public int zone;

    public void Start()
    {
        stats = new StatObject();
        stats.Stealth = 20;
        stats.Health = 100;

        if (zone == 1)
        {
            stats.Attack = 20;
            stats.Defense = 20;
        }
        else if (zone == 2)
        {
            stats.Attack = 30;
            stats.Defense = 30;
        }
        else if (zone == 3)
        {
            stats.Attack = 40;
            stats.Defense = 40;
        }
        else if (zone == 4)
        {
            stats.Attack = 50;
            stats.Defense = 50;
        }
    }


}
