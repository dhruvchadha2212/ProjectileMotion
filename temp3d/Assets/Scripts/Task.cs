using UnityEngine;

public abstract class Task
{
    protected AudioClip TaskAudio;
    protected string TaskString;

    public abstract bool IsCompleted();
}

public class ButtonPressTask : Task
{
    string requiredButton;

    ButtonPressTask(Question task)
    {
        this.requiredButton = task.id;
    }

    public override bool IsCompleted()
    {
        return UIManager.mostRecentlyClickedButton == requiredButton;
    }
}

public class BallLaunchTask : Task
{
    public override bool IsCompleted()
    {
        throw new System.NotImplementedException();
    }
}