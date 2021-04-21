using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Stat System/Stats")]
public class StatObject : ScriptableObject
{
    public int Stealth;
    public int Attack;
    public int Health;
    public int Defense;
    public int goldAmount;


    public void changeAttack(int change)
    {
        Attack += change;
    }
    public void changeDefense(int change)
    {
        Defense += change;
    }
    public void changeStealth(int change)
    {
        Stealth += change;
    }
    public void changeHealth(int change)
    {
        Health += change;
    }
    public void changeGold(int change)
    {
        goldAmount += change;
    }
}
