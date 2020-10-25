using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [Header("Questions (NOT IN ORDER)")]
    [SerializeField] private List<Question> questions;

    private static Dictionary<string, Question> questionIdToQuestionMap = new Dictionary<string, Question>();

    private void Start()
    {
        foreach (Question question in questions)
        {
            questionIdToQuestionMap.Add(question.id, question);
        }
    }

    public static Question GetQuestion(string questionId)
    {
        return questionIdToQuestionMap[questionId];
    }
}
