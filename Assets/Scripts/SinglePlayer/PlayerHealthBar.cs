using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthBar : HealthBar
{
    [SerializeField] TextMeshProUGUI text;

    public override void HandleHealthChanged(float pct)
    {
        int i = (int)(pct * 100);
        text.text = i.ToString() + "%";
        StartCoroutine(ChangeToPct(pct));
    }
}
