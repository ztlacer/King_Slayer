using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicTransition : MonoBehaviour
{
    [SerializeField]public AudioClip defaultAudio;
    private AudioSource clip1, clip2;
    private bool isPlayingClip1;
    public static MusicTransition instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        clip1 = gameObject.AddComponent<AudioSource>();
        clip2 = gameObject.AddComponent<AudioSource>();
        isPlayingClip1 = true;
        SwapTrack(defaultAudio);
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeClip(newClip));
        // Toggle
        isPlayingClip1 = !isPlayingClip1;
    }

    public void returnToDefault()
    {
        SwapTrack(defaultAudio);
    }

    private IEnumerator FadeClip(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElapse = 0;
        if (isPlayingClip1)
        {
            clip2.clip = newClip;
            clip2.Play();

            while(timeElapse < timeToFade)
            {
                clip2.volume = Mathf.Lerp(0, 1, timeElapse / timeToFade);
                clip1.volume = Mathf.Lerp(1, 0, timeElapse / timeToFade);
                timeElapse += Time.deltaTime;
                yield return null;
            }

            clip1.Stop();
        }
        else
        {
            clip1.clip = newClip;
            clip1.Play();

            while (timeElapse < timeToFade)
            {
                clip1.volume = Mathf.Lerp(0, 1, timeElapse / timeToFade);
                clip2.volume = Mathf.Lerp(1, 0, timeElapse / timeToFade);
                timeElapse += Time.deltaTime;
                yield return null;
            }
            clip2.Stop();
        }
    }
}
