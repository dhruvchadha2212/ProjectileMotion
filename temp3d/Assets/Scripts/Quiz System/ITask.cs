using UnityEngine;

public interface ITask
{
    void SetUp();
    bool IsCompleted();
}

public class ButtonPressTask : ITask
{
    private GameButton requiredButton;

    public ButtonPressTask(GameButton gameButton)
    {
        requiredButton = gameButton;
    }

    public void SetUp()
    {
        GameState.mostRecentlyClickedGameButton = GameButton.NONE;
        UIManager.HideAllButtonsExcept(requiredButton); //also reset buttons to required state
        Question taskInfo = Dialogues.GetButtonPressTaskInfo(requiredButton);
        AudioManager.PlayInterruptible(taskInfo.audio);
    }

    public bool IsCompleted()
    {
        return GameState.mostRecentlyClickedGameButton == requiredButton;
    }
}

public class BallLaunchTask : ITask
{
    public void SetUp()
    {
        Question taskInfo = Dialogues.GetBallLaunchTaskInfo();
        AudioManager.PlayInterruptible(taskInfo.audio);
    }

    public bool IsCompleted()
    {
        return GameState.ballHasBouncedOnce == true;
    }
}

public class QuestionTask : ITask
{
    private QuestionName requiredQuestion;

    public QuestionTask(QuestionName questionName)
    {
        requiredQuestion = questionName;
    }

    public void SetUp()
    {
        GameState.currentQuestionName = requiredQuestion;
        GameState.currentQuestionHasBeenAnsweredCorrectly = false;
        UIManager.DisplayCurrentQuestion();
        AudioManager.PlayCurrentQuestionInterruptible();
    }

    public bool IsCompleted()
    {
        return GameState.currentQuestionHasBeenAnsweredCorrectly;
        // TODO figure out code for random appreciation
    }
}

public class WaitTask : ITask
{
    private float timeStamp;
    private float secondsToWait;

    public WaitTask (float seconds)
    {
        secondsToWait = seconds;
    }

    public void SetUp()
    {
        timeStamp = Time.time;
    }

    public bool IsCompleted()
    {
        return Time.time - timeStamp > secondsToWait;
    }
}