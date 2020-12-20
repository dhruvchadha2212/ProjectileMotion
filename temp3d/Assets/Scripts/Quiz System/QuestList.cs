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
                new BallLaunchTask(),
                new QuestionTask(QuestionName.NOTICE_ONLY_VERTICAL_MOTION) //pausable, if user is unable to visualise
            )
        },
        {
            QuestName.VISUALISE_HORIZONTAL_COMPONENT_OF_VELOCITY, new Quest
            (
                //new ButtonPressTask(GameButton.VERTICAL_CAMERA), //say vertical "observer" instead of "camera", or "follow" the ball vertically
                //new QuestionTask(QuestionName.NOW_WE_MOVE_UPWARDS),
                //new WaitTask(1f),
                //new BallLaunchTask(),
                new ButtonPressTask(GameButton.TOGGLE_BACKGROUND), //handle if user didnt listen/forgot what to do.
                new BallLaunchTask(),
                new QuestionTask(QuestionName.NOTICE_ONLY_HORIZONTAL_MOTION)
            )
        }
    };
}
