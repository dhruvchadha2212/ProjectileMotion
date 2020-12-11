using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private ITask[] tasks;

    public Quest(params ITask[] tasks)
    {
        this.tasks = tasks;
    }

    public IEnumerator BeginQuest()
    {
        foreach (ITask task in tasks)
        {
            task.SetUp();
            yield return new WaitUntil(task.IsCompleted);
        }
    }
}


