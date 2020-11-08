using System.Collections.Generic;

public class QuestList
{
    public static Dictionary<string, Quest> questNameToQuestMap = new Dictionary<string, Quest>
    {
        {
            "VisualiseVerticalComponentOfVelocity", new Quest
            (
                new ButtonPressTask(GameButton.HORIZONTAL_CAMERA),
                new BallLaunchTask()
            )
        }
    };
}
