using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static IEnumerator PlayAndWaitFor(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public static void PlayInterruptible(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public static IEnumerator PlayAndWaitFor(QuestionName questionName) //remove these methods, should play audioclip only, shouldnt need to search
    {
        audioSource.Stop();
        audioSource.clip = Dialogues.GetQuestion(questionName).audio;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public static void PlayCurrentQuestionInterruptible()
    {
        audioSource.Stop();
        audioSource.clip = Dialogues.GetQuestion(GameState.currentQuestionName).audio;
        audioSource.Play();
    }

    public static void StopPlayingAudio()
    {
        audioSource.Stop();
    }
}
