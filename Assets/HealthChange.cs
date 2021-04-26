using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{

    public Slider slider;

    public StatObject playerStats;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void ModifyHealth(int amount)
    {
        playerStats.Health += amount;

        SetHealth(playerStats.Health);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            ModifyHealth(-10);
        }
    }
}
