using System.Collections;
using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Dialogues dialogues;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        StartCoroutine("StartGameNarrative");
    }

    private IEnumerator StartGameNarrative()
    {
        //TODO replace with new menu scene
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("introduction")));
        yield return StartCoroutine(GiveLaunchBallTask());
        yield return StartCoroutine(AskQuestion("whatTrajectory"));
        //yield return StartCoroutine(AskQuestion("whyCurved"));
        //yield return StartCoroutine(AskQuestion("howManyAxes"));
        //yield return StartCoroutine(GiveTask1()); //Horizontal camera
        //yield return StartCoroutine(AskQuestion("anythingUnique"));
        //yield return StartCoroutine(AskQuestion("anythingUnique"));
        //yield return StartCoroutine(AskQuestion("relativeYZeroClear"));
        yield return new WaitForSeconds(1);
        //yield return StartCoroutine(AskQuestion("concetsOf1DApplicable"));

        //yield return StartCoroutine(AskQuestion("onlyVerticalObservable"));
        //yield return StartCoroutine(GiveTask2()); //Vertical Camera
    }

    private IEnumerator AskQuestion(string questionKey)
    {
        Question currentQuestion = dialogues.GetQuestion(questionKey);
        uiManager.DisplayQuestion(currentQuestion);
        audioManager.PlayInterruptible(currentQuestion.QuestionAudio);
        yield return new WaitUntil(() => currentQuestion.IsAnsweredCorrectly);
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetRandomAppreciation()));
    }

    private IEnumerator GiveTask2()
    {
        yield return StartCoroutine(GiveButtonPressTask("clickVerticalCamera"));
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask());
    }

    private IEnumerator GiveTask1()
    {
        yield return StartCoroutine(GiveButtonPressTask("coolPressHorizontalCam"));
        yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("nowWeMoveSideways")));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(GiveLaunchBallTask());
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask());
    }

    private IEnumerator GiveButtonPressTask(string taskKey)
    {
        Task task = dialogues.GetTask(taskKey);
        yield return StartCoroutine(audioManager.PlayAndWaitFor(task.TaskAudio));
        UIManager.mostRecentlyClickedButton = string.Empty;
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
