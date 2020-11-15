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
            task.setUp();
            yield return new WaitUntil(task.IsCompleted);
        }
    }
}


