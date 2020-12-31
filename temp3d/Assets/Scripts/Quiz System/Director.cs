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
        //      TODO replace with new menu scene
        yield return StartCoroutine(AudioManager.PlayAndWaitFor(Dialogues.GetQuestion(QuestionName.INTRODUCTION).audio));
        //      TODO solve the "question without panel/audio only" issue
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(TaskManager.WaitForTaskCompletion(new BallLaunchTask()));
        yield return new WaitForSeconds(2f);
        ////      TODO launch the ball a couple of times to get comfortable, pause
        yield return StartCoroutine(AskQuestion(QuestionName.WHAT_TRAJECTORY));
        yield return StartCoroutine(AskQuestion(QuestionName.WHY_CURVED));
        yield return StartCoroutine(AskQuestion(QuestionName.HOW_MANY_AXES));
        //      TODO good job ! you are an intuitive person.
        yield return StartCoroutine(BeginQuest(QuestName.VISUALISE_VERTICAL_COMPONENT_OF_VELOCITY));
        yield return StartCoroutine(AskQuestion(QuestionName.VERTICAL_IS_INDEPENDENT));
        yield return StartCoroutine(AskQuestion(QuestionName.VERTICAL_COMPONENT_FORMULA));
        yield return StartCoroutine(AskQuestion(QuestionName.TIME_OF_FLIGHT_CAN_BE_FOUND));
        yield return StartCoroutine(AskQuestion(QuestionName.WHICH_EQUATION_TIME_OF_FLIGHT));
        //      TODO Quest 1 completed ! (use enum QUEST_1_COMPLETED). Show time of flight formula card
        yield return StartCoroutine(BeginQuest(QuestName.VISUALISE_HORIZONTAL_COMPONENT_OF_VELOCITY));
        yield return StartCoroutine(AskQuestion(QuestionName.ANY_HORIZONTAL_FORCE));
        yield return StartCoroutine(AskQuestion(QuestionName.IS_HORIZONTAL_VELOCITY_AFFECTED));
        yield return StartCoroutine(AskQuestion(QuestionName.HORIZONTAL_COMPONENT_FORMULA));
        yield return StartCoroutine(AskQuestion(QuestionName.RANGE_CAN_BE_FOUND));
        yield return StartCoroutine(AskQuestion(QuestionName.RANGE_FORMULA));
        //      TODO Quest 2 completed ! (use enum QUEST_2_COMPLETED). Show range of flight formula card
        //      TODO all formulae revision card at the end
    }

    private IEnumerator AskQuestion(QuestionName questionName)
    {
        GameState.currentQuestionName = questionName;
        GameState.currentQuestionHasBeenAnsweredCorrectly = false;
        UIManager.DisplayCurrentQuestion();
        AudioManager.PlayCurrentQuestionInterruptible();
        yield return new WaitUntil(() => GameState.currentQuestionHasBeenAnsweredCorrectly);
        //yield return StartCoroutine(audioManager.PlayAndWaitFor(dialoguesOld.GetRandomAppreciation()));
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator BeginQuest(QuestName questName)
    {
        yield return StartCoroutine(questManager.BeginQuest(questName));
        UIManager.ShowAllButtons();
    }
}
