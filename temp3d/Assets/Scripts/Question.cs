using System;
using UnityEngine;

// Model object to hold all attributes related to a question
[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class Question : ScriptableObject
{
    public string id;
    public QuestionType type;

    [TextArea]
    public string text;
    public AudioClip audio;
    public string explanation;
    public GameObject image;

    public Option[] options;
}

[Serializable]
public class Option
{
    public string text;
    public GameObject image;
    public bool isCorrect;
    public string tip;
}