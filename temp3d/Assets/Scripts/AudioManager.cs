using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator PlayAndWaitFor(AudioClip audioClip)
    {
        PlayInterruptible(audioClip);
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public void PlayInterruptible(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
