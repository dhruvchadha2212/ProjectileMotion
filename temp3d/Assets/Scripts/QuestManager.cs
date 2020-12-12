using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public void BeginQuest(string questName)
    {
        Quest currentQuest = QuestList.questNameToQuestMap[questName];
        foreach (ITask task in currentQuest.tasks)
        {
            StartCoroutine(TaskManager.WaitForTaskCompletion(task));
        }
    }
}
