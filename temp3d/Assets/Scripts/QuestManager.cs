using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public IEnumerator BeginQuest(string questName)
    {
        yield return StartCoroutine(QuestList.questNameToQuestMap[questName].BeginQuest());
    }
}
