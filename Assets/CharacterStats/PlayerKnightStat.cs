using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knight Player", menuName = "Stats/Player/Knight")]
public class PlayerKnightStat : MonoBehaviour
{
    public StatObject stats;

    

    public void Awake()
    {
        stats.Stealth = 20;
        stats.Attack = 20;
        stats.Health = 20;
        stats.Defense = 20;
    }

    



}
