using System.Collections;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static IEnumerator WaitForTaskCompletion(ITask task)
    {
        task.SetUp();
        yield return new WaitUntil(task.IsCompleted);
    }
}
