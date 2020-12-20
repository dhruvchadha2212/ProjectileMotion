using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private QuestionNameToQuestionDictionary questionNameToQuestionMap;
    private static QuestionNameToQuestionDictionary questionNameToQuestionMapStatic;

    [SerializeField] private GameButtonToQuestionDictionary gameButtonToTaskInfoMap;
    private static GameButtonToQuestionDictionary gameButtonToTaskInfoMapStatic;

    [SerializeField] private Question ballLaunchTaskInfo;
    private static Question ballLaunchTaskInfoStatic;

    private void Start()
    {
        gameButtonToTaskInfoMapStatic = gameButtonToTaskInfoMap;
        questionNameToQuestionMapStatic = questionNameToQuestionMap;
        ballLaunchTaskInfoStatic = ballLaunchTaskInfo;
    }

    public static Question GetQuestion(QuestionName questionName)
    {
        return questionNameToQuestionMapStatic[questionName];
    }

    public static Question GetButtonPressTaskInfo(GameButton gameButton)
    {
        return gameButtonToTaskInfoMapStatic[gameButton];
    }

    public static Question GetBallLaunchTaskInfo()
    {
        return ballLaunchTaskInfoStatic;
    }
}
