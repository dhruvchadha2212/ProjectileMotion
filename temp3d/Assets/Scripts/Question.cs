using UnityEngine;
using UnityEngine.UI;
public class Question
{
    public AudioClip QuestionAudio { get; set; }
    public string QuestionString { get; set; }
    public Image QuestionImage { get; set; }
    public string[] Options { get; set; }
    public int CorrectOptionIndex { get; set; }
    public string[] OptionTips { get; set; }
    public bool IsPausable { get; set; }
    public bool IsAnsweredCorrectly { get; set; }
}