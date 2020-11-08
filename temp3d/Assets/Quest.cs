using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private Task[] tasks;

    public Quest(params Task[] tasks)
    {
        this.tasks = tasks;
    }

    public IEnumerator BeginQuest()
    {
        foreach (Task task in tasks)
        {
            if (task.GetType() == typeof(ButtonPressTask)) {
                GameState.mostRecentlyClickedGameButton = GameButton.NONE;
                //add code to disable all other buttons
            }
            AudioManager.PlayInterruptible(task.GetTaskAudio());
            yield return new WaitUntil(task.IsCompleted);
        }
    }
}


