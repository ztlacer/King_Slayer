using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;

    [SerializeField] public string damagingWeapon;

    [SerializeField] private StatObject playerStats;

    //[SerializeField] private TextMesh text;


    public int currentHealth;




    public event Action<float> onHealthPctChanged = delegate { };


    public StatObject ownStats;

    public StatObject enemyStats;



    private void OnEnable()
    {
        playerStats.Health = maxHealth;
    }

    public void ModifyHealth(int amount)
    {


        currentHealth += amount;


        float currentHealthPct = (float)playerStats.Health / (float)maxHealth;
        onHealthPctChanged(currentHealthPct);
        //text.text = currentHealthPct.ToString() + "%";

    }



    
}
