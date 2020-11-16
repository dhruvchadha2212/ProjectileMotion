using System.Collections;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private DialoguesOld dialoguesOld;
    [SerializeField] private Dialogues dialogues;
    [SerializeField] private QuestManager questManager;

    void Start()
    {
        StartCoroutine("StartGameNarrative");
    }

    private IEnumerator StartGameNarrative()
    {
        //TODO replace with new menu scene
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialogues.GetMiscAudioClip("introduction")));
        //launch the ball a couple of times to get comfortable
        //yield return StartCoroutine(WaitForBallLaunch());
        yield return StartCoroutine(AskQuestion(QuestionName.WHAT_TRAJECTORY));
        //yield return StartCoroutine(AskQuestion("whyCurved"));
        //yield return StartCoroutine(AskQuestion("howManyAxes"));
        //good job ! you are an intuitive person.
        yield return StartCoroutine(questManager.BeginQuest("VisualiseVerticalComponentOfVelocity"));
        //yield return StartCoroutine(VisualiseVerticalComponentOfVelocity());


        ////yield return StartCoroutine(ShowExplanation("onlyVerticalObservable")); //deprecated

        ////now show explanation card instead of next question
        ////then let user save the card for later
        //yield return StartCoroutine(AskQuestion("conceptsOf1DApplicable"));

        ////let user read themself. If required, they can play.
        //yield return StartCoroutine(AskQuestion("onlyVerticalObservable"));


        ////Level 1 cleared -> the Time of flight of the ball is -
        //yield return StartCoroutine(VisualiseHorizontalComponentOfVelocity()); //Vertical Camera
        ////add another panel for task audios too.Long task audios need to be written too.
        //yield return StartCoroutine(AskQuestion("onlyHorizontalObservable"));
        ////Level 2 cleared -> the Range of the ball is -
    }

    private IEnumerator AskQuestion(QuestionName questionName)
    {
        GameState.currentQuestionName = questionName;
        UIManager.DisplayCurrentQuestion();
        AudioManager.PlayCurrentQuestionInterruptible();
        yield return new WaitUntil(() => GameState.currentQuestionHasBeenAnsweredCorrectly);
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialoguesOld.GetRandomAppreciation()));
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator VisualiseVerticalComponentOfVelocity()
    {
        //yield return StartCoroutine(WaitForButtonPress("coolPressHorizontalCam")); // TODO Instead of camera, use word "observer"
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialoguesOld.GetMiscAudioClip("nowWeMoveSideways")));
        yield return new WaitForSeconds(0.5f);
        //yield return StartCoroutine(WaitForBallLaunch());
        //yield return StartCoroutine(WaitForButtonPress("pressToggleBackground"));
        //yield return StartCoroutine(WaitForBallLaunch());
        //yield return StartCoroutine(AskQuestion("noticeOnlyVerticalMotion"));
    }

    private IEnumerator VisualiseHorizontalComponentOfVelocity()
    {
        //yield return StartCoroutine(WaitForButtonPress("clickVerticalCamera")); //say vertical "observer" or something like that, or "follow" the ball vertically
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialoguesOld.GetMiscAudioClip("nowWeMoveUpwards")));
        //yield return StartCoroutine(WaitForBallLaunch());
        //yield return StartCoroutine(WaitForButtonPress("pressToggleBackground"));
        //yield return StartCoroutine(WaitForBallLaunch());
        yield return new WaitForSeconds(0.5f);
    }
}
