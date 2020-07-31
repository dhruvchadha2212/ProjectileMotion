using System.Collections;
using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject cameraControls;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Dialogues dialogues;

    public bool startButtonClicked { get; set; } = false;
    public bool verticalCameraButtonClicked { get; set; } = false;
    private AudioSource audioSource;

    void Start()
    {
        sphere.SetActive(false);
        startGame.SetActive(false);
        cameraControls.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("StartGameNarrative");
    }

    private IEnumerator StartGameNarrative()
    {
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(audioSource, dialogues.GetMiscAudioClip("introduction")));
        startGame.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => startButtonClicked);
        InitialiseGame();
        //yield return new WaitForSeconds(8.0f);//gap before first question
        //yield return StartCoroutine(AskQuestion("whatTrajectory"));
        //yield return StartCoroutine(AskQuestion("whyCurved"));
        //yield return StartCoroutine(AskQuestion("howManyAxes"));
        //yield return StartCoroutine(GiveTask1()); //Horizontal camera
        //yield return StartCoroutine(AskQuestion("anythingUnique"));
        //yield return StartCoroutine(AskQuestion("anythingUnique"));
        //yield return StartCoroutine(AskQuestion("relativeYZeroClear"));
        //yield return new WaitForSeconds(1);
        //yield return StartCoroutine(AskQuestion("concetsOf1DApplicable"));

        //yield return StartCoroutine(AskQuestion("onlyVerticalObservable"));
        //yield return StartCoroutine(GiveTask2()); //Vertical Camera
    }

    private IEnumerator AskQuestion(string questionKey)
    {
        Question currentQuestion = dialogues.GetQuestion(questionKey);
        uiManager.DisplayQuestion(currentQuestion);
        AudioManager.PlayInterruptible(audioSource, currentQuestion.QuestionAudio);
        yield return new WaitUntil(() => currentQuestion.IsAnsweredCorrectly);
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(audioSource, dialogues.GetRandomAppreciation()));
    }

    private IEnumerator GiveTask2()
    {
        yield return StartCoroutine(GiveButtonPressTask("clickVerticalCamera"));
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask("launchBall"));
    }

    private IEnumerator GiveTask1()
    {
        yield return StartCoroutine(GiveButtonPressTask("coolPressHorizontalCam"));
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(audioSource, dialogues.GetMiscAudioClip("nowWeMoveSideways")));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(GiveLaunchBallTask("launchBall"));
        yield return StartCoroutine(GiveButtonPressTask("pressToggleBackground"));
        yield return StartCoroutine(GiveLaunchBallTask("launchBall"));
    }

    private IEnumerator GiveButtonPressTask(string taskKey)
    {
        Task task = dialogues.GetTask(taskKey);
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(audioSource, task.TaskAudio));
        UIManager.mostRecentlyClickedButton = string.Empty;
        yield return new WaitUntil(task.IsCompleted);
    }

    private IEnumerator GiveLaunchBallTask(string taskKey)
    {
        Task task = dialogues.GetTask(taskKey);
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(audioSource, task.TaskAudio));
        yield return new WaitUntil(task.IsCompleted);
        yield return new WaitForSeconds(1);
    }

    private void InitialiseGame() //replace with new menu scene
    {
        startGame.SetActive(false);
        sphere.SetActive(true);
        cameraControls.SetActive(true);
    }
}
