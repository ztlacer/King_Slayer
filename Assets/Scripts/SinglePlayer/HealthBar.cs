using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;

    [SerializeField] private float updateSpeedSeconds = .5f;

    public GameObject parent;

    private void Awake()
    {
        GetComponentInParent<Health>().onHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foreground.fillAmount;

        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreground.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foreground.fillAmount = pct;
        if (foreground.fillAmount <= 0)
        {
            Destroy(parent);
        }
    }

}
