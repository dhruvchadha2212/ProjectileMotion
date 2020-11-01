using System.Collections.Generic;

public class QuestList
{
    public static Dictionary<string, Quest> questNameToQuestMap = new Dictionary<string, Quest>
    {
        {
            "VisualiseVerticalComponentOfVelocity", new Quest
            (
                new ButtonPressTask(GameButton.TOGGLE_BACKGROUND),
                new ButtonPressTask(GameButton.TOGGLE_BACKGROUND)
            )
        }
    };
}
