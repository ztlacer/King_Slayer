using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;

    [SerializeField] private float updateSpeedSeconds = .5f;

    [SerializeField] private Health health;

    public GameObject parent;



    private void Awake()
    {
        health.onHealthPctChanged += HandleHealthChanged;
    }

    public virtual void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    protected IEnumerator ChangeToPct(float pct)
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
            if (parent.tag == "Player")
            {
                EndStateManager.instance.initiateEndScreen("You Lose");
            }
            MusicTransition.instance.returnToDefault();
        }
    }

}
