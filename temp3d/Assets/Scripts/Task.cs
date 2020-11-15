using UnityEngine;

public abstract class Task
{
    public abstract void setUp();
    public abstract bool IsCompleted();
}

public class ButtonPressTask : Task
{
    private GameButton requiredButton;

    public ButtonPressTask(GameButton gameButton)
    {
        requiredButton = gameButton;
    }

    public override void setUp()
    {
        // GameState changes
        GameState.mostRecentlyClickedGameButton = GameButton.NONE;
        // TODO add code to disable all other buttons
        // Setup
        Question taskInfo = Dialogues.GetButtonPressTaskInfo(requiredButton);
        AudioManager.PlayInterruptible(taskInfo.audio);
    }

    public override bool IsCompleted()
    {
        return GameState.mostRecentlyClickedGameButton == requiredButton;
    }
}

public class BallLaunchTask : Task
{
    public override void setUp()
    {
        Question taskInfo = Dialogues.GetBallLaunchTaskInfo();
        AudioManager.PlayInterruptible(taskInfo.audio);
    }

    public override bool IsCompleted()
    {
        return GameState.ballHasBouncedOnce == true;
    }
}

public class QuestionTask : Task
{

    private QuestionName requiredQuestion;

    public QuestionTask(QuestionName questionName)
    {
        requiredQuestion = questionName;
    }

    public override void setUp()
    {
        GameState.currentQuestionName = requiredQuestion;
        UIManager.DisplayCurrentQuestion();
        AudioManager.PlayCurrentQuestionInterruptible();
    }

    public override bool IsCompleted()
    {
        return GameState.currentQuestionHasBeenAnsweredCorrectly;
        // TODO figure out code for random appreciation
    }
}