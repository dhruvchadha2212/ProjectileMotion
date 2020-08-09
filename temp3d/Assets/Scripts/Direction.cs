using System.Collections;
using UnityEngine;

public class Direction : MonoBehaviour
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
        //yield return StartCoroutine(GiveLaunchBallTask());
        //yield return StartCoroutine(AskQuestion("whatTrajectory"));
        //yield return StartCoroutine(AskQuestion("whyCurved"));
        //yield return StartCoroutine(AskQuestion("howManyAxes"));
        //good job ! you are an intuitive person.
        //yield return StartCoroutine(VisualiseVerticalComponentOfVelocity());
        yield return StartCoroutine(AskQuestion("anythingUnique"));
        //yield return StartCoroutine(AskQuestion("relativeYZeroClear"));

        //now show explanation card instead of next question
        //yield return StartCoroutine(AskQuestion("conceptsOf1DApplicable"));

        //let user read themself. If required, they can play.
        yield return StartCoroutine(AskQuestion("onlyVerticalObservable"));

        yield return StartCoroutine(GiveTask2()); //Vertical Camera
    }

    private IEnumerator AskQuestion(string questionKey)
    {
        Question currentQuestion = dialogues.GetQuestion(questionKey);
        uiManager.DisplayQuestion(currentQuestion);
        audioManager.PlayInterruptible(currentQuestion.QuestionAudio);
        yield return new WaitUntil(() => currentQuestion.IsAnsweredCorrectly);
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetRandomAppreciation()));
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator GiveTask2()
    {
        yield return StartCoroutine(GiveButtonPressTask("clickVerticalCamera"));
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask());
    }

    private IEnumerator VisualiseVerticalComponentOfVelocity()
    {
        //yield return StartCoroutine(GiveButtonPressTask("coolPressHorizontalCam"));
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("nowWeMoveSideways")));
        //yield return new WaitForSeconds(0.5f);
        //yield return StartCoroutine(GiveLaunchBallTask());
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask());
    }

    private IEnumerator GiveButtonPressTask(string taskKey)
    {
        Task task = dialogues.GetTask(taskKey);
        UIManager.mostRecentlyClickedButton = string.Empty;
        yield return StartCoroutine(audioManager.PlayAndWaitFor(task.TaskAudio));
        yield return new WaitUntil(task.IsCompleted);
    }

    private IEnumerator GiveLaunchBallTask()
    {
        Task task = dialogues.GetTask("launchBall");
        yield return StartCoroutine(audioManager.PlayAndWaitFor(task.TaskAudio));
        yield return new WaitUntil(task.IsCompleted);
        yield return new WaitForSeconds(1);
    }
}
