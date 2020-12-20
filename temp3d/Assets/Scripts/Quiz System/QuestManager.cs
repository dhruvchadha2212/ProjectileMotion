using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public IEnumerator BeginQuest(QuestName questName)
    {
        Quest currentQuest = QuestList.questNameToQuestMap[questName];
        foreach (ITask task in currentQuest.tasks)
        {
            yield return StartCoroutine(TaskManager.WaitForTaskCompletion(task));
        }
    }
}
