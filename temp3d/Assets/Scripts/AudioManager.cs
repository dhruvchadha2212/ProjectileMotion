using System.Collections;
using UnityEngine;

public class AudioManager
{
    public static IEnumerator PlayAndWaitFor(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public static void PlayInterruptible(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
