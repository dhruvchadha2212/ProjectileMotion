using UnityEngine;
public class Question
{
    public AudioClip QuestionAudio { get; set; }
    public string QuestionString { get; set; }
    public string[] Options { get; set; }
    public int CorrectOptionIndex { get; set; }
    public string[] OptionTips { get; set; }
    public bool IsAnsweredCorrectly;
}