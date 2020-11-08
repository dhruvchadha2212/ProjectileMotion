using UnityEngine;

public abstract class Task
{
    protected AudioClip taskAudio;
    protected string taskString;

    public abstract bool IsCompleted();

    public AudioClip GetTaskAudio()
    {
        return taskAudio;
    }
    public string GetTaskString()
    {
        return taskString;
    }
}

public class ButtonPressTask : Task
{
    private GameButton requiredButton;

    public ButtonPressTask(GameButton gameButton)
    {
        requiredButton = gameButton;
        Question taskInfo = Dialogues.GetButtonPressTaskInfo(gameButton);
        taskString = taskInfo.text;
        taskAudio = taskInfo.audio;
    }

    public override bool IsCompleted()
    {
        return GameState.mostRecentlyClickedGameButton == requiredButton;
    }
}

public class BallLaunchTask : Task
{
    public BallLaunchTask()
    {
        Question taskInfo = Dialogues.GetBallLaunchTaskInfo();
        taskString = taskInfo.text;
        taskAudio = taskInfo.audio;
    }

    public override bool IsCompleted()
    {
        return GameState.ballHasBouncedOnce == true;
    }
}