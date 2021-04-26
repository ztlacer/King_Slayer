using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private string damagingWeapon;

    //[SerializeField] private TextMesh text;

    private int currentHealth;

    public event Action<float> onHealthPctChanged = delegate { };


    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        onHealthPctChanged(currentHealthPct);
        //text.text = currentHealthPct.ToString() + "%";

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damagingWeapon)
        {
            ModifyHealth(-10);
        }
    }
}
