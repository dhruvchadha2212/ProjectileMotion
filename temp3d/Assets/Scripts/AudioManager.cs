using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static IEnumerator PlayAndWaitFor(string questionKey)
    {
        audioSource.Stop();
        audioSource.clip = Dialogues.GetQuestion(questionKey).audio;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public static void PlayInterruptible(string questionKey)
    {
        audioSource.Stop();
        audioSource.clip = Dialogues.GetQuestion(questionKey).audio;
        audioSource.Play();
    }

    public static void StopPlayingAudio()
    {
        audioSource.Stop();
    }
}
