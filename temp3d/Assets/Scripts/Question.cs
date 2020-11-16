using System;
using UnityEngine;

// Model object to hold all attributes related to a question
[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class Question : ScriptableObject
{
    public QuestionName questionName;
    public QuestionType type;

    [TextArea]
    public string text;
    public AudioClip audio;
    public string explanation;
    public GameObject image;

    public Option[] options;
}