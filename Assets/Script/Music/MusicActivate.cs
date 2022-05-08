using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicActivate : MonoBehaviour
{
    public static MusicActivate instance;

    private AudioSource track1,track2;
    private bool isPlayingTrack1;
    public AudioClip defultAmbience;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        track1=gameObject.AddComponent<AudioSource>();
        track2=gameObject.AddComponent<AudioSource>();
        isPlayingTrack1 = true;

        SwapTrack(defultAmbience);
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();
        StartCoroutine(fadeTrack(newClip));
        isPlayingTrack1 = !isPlayingTrack1;
    }

    public void ReturnToDefult()
    {
        SwapTrack(defultAmbience);
    }

    private IEnumerator fadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElapsed = 0;
        if (isPlayingTrack1)
        {
            track2.clip = newClip;
            track2.Play();

            while (timeElapsed < timeToFade)
            {
                track2.volume = Mathf.Lerp(0, 0.7f, timeElapsed / timeToFade);
                track1.volume = Mathf.Lerp(0.5f, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            track1.Stop();
        }
        else
        {
            track1.clip = newClip;
            track1.Play();

            while (timeElapsed < timeToFade)
            {
                track1.volume = Mathf.Lerp(0, 0.5f, timeElapsed / timeToFade);
                track2.volume = Mathf.Lerp(0.7f, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            track2.Stop();
        }
    }
}
