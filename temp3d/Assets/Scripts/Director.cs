using System.Collections;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Dialogues dialogues;
    [SerializeField] public AudioManager audioManager;

    void Start()
    {
        StartCoroutine("StartGameNarrative");
    }

    private IEnumerator StartGameNarrative()
    {
        //TODO replace with new menu scene
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("introduction")));
        //launch the ball a couple of times to get comfortable
        yield return StartCoroutine(WaitForBallLaunch());
        yield return StartCoroutine(AskQuestion("whatTrajectory"));
        yield return StartCoroutine(AskQuestion("whyCurved"));
        yield return StartCoroutine(AskQuestion("howManyAxes"));
        //good job ! you are an intuitive person.
        yield return StartCoroutine(VisualiseVerticalComponentOfVelocity());
        yield return StartCoroutine(ShowExplanation("onlyVerticalObservable"));

        //now show explanation card instead of next question
        //then let user save the card for later
        yield return StartCoroutine(AskQuestion("conceptsOf1DApplicable"));

        //let user read themself. If required, they can play.
        yield return StartCoroutine(AskQuestion("onlyVerticalObservable"));


        //Level 1 cleared -> the Time of flight of the ball is -
        yield return StartCoroutine(VisualiseHorizontalComponentOfVelocity()); //Vertical Camera
        //add another panel for task audios too.Long task audios need to be written too.
        yield return StartCoroutine(AskQuestion("onlyHorizontalObservable"));
        //Level 2 cleared -> the Range of the ball is -
    }

    private IEnumerator AskQuestion(string questionKey)
    {
        Question currentQuestion = dialogues.GetQuestion(questionKey);
        uiManager.DisplayQuestion(currentQuestion);
        audioManager.PlayInterruptible(currentQuestion.QuestionAudio);
        yield return new WaitUntil(() => currentQuestion.HasBeenAnsweredCorrectly);
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetRandomAppreciation()));
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator ShowExplanation(string explanationKey)
    {
        Explanation currentExplanation = dialogues.GetExplanation(explanationKey);
        uiManager.DisplayExplanation(currentExplanation);
        yield return new WaitUntil(() => currentExplanation.IsUnderstood);
    }

    private IEnumerator VisualiseVerticalComponentOfVelocity()
    {
        yield return StartCoroutine(WaitForButtonPress("coolPressHorizontalCam")); //Instead of camera, use word "observer"
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("nowWeMoveSideways")));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(WaitForBallLaunch());
        yield return StartCoroutine(WaitForButtonPress("pressToggleBackground"));
        yield return StartCoroutine(WaitForBallLaunch());
        yield return StartCoroutine(AskQuestion("noticeOnlyVerticalMotion"));
    }

    private IEnumerator VisualiseHorizontalComponentOfVelocity()
    {
        yield return StartCoroutine(WaitForButtonPress("clickVerticalCamera")); //say vertical "observer" or something like that, or "follow" the ball vertically
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("nowWeMoveUpwards")));
        yield return StartCoroutine(WaitForBallLaunch());
        yield return StartCoroutine(WaitForButtonPress("pressToggleBackground"));
        yield return StartCoroutine(WaitForBallLaunch());
        
    }

    private IEnumerator WaitForButtonPress(string taskKey)
    {
        Task task = dialogues.GetTask(taskKey);
        UIManager.mostRecentlyClickedButton = string.Empty;
        yield return StartCoroutine(audioManager.PlayAndWaitFor(task.TaskAudio));
        yield return new WaitUntil(task.IsCompleted);
    }

    private IEnumerator WaitForBallLaunch()
    {
        Task task = dialogues.GetTask("launchBall");
        yield return StartCoroutine(audioManager.PlayAndWaitFor(task.TaskAudio));
        yield return new WaitUntil(task.IsCompleted);
        yield return new WaitForSeconds(1);
    }
}
