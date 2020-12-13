using System.Collections.Generic;

public class QuestList
{
    public static Dictionary<QuestName, Quest> questNameToQuestMap = new Dictionary<QuestName, Quest>
    {
        {
            QuestName.VISUALISE_VERTICAL_COMPONENT_OF_VELOCITY, new Quest
            (
                new ButtonPressTask(GameButton.HORIZONTAL_CAMERA),
                new QuestionTask(QuestionName.NOW_WE_MOVE_SIDEWAYS),
                new WaitTask(1f),
                new BallLaunchTask(),
                new ButtonPressTask(GameButton.TOGGLE_BACKGROUND),
                new BallLaunchTask()
            )
        }
    };
}
