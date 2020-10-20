using UnityEngine;
using UnityEngine.UI;

// Model object to hold all attributes related to a question
public class Question
{
    public QuestionType QuestionType { get; set; }
    public AudioClip QuestionAudio { get; set; }
    public string QuestionString { get; set; }
    public string ExplanationString { get; set; }
    public Image QuestionImage { get; set; }
    public string[] Options { get; set; }
    public int CorrectOptionNumber { get; set; }
    public string[] OptionTips { get; set; }
    public bool IsPausable { get; set; }
    public bool HasBeenAnsweredCorrectly { get; set; }
}