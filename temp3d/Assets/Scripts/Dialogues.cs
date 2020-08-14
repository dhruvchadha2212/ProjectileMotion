using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [Header("Introduction")]
    [SerializeField] private AudioClip introduction;
    [Header("Questions")]
    [SerializeField] private AudioClip whatTrajectory;
    [SerializeField] private AudioClip whyCurved;
    [SerializeField] private AudioClip howManyAxes;
    [SerializeField] private AudioClip noticeOnlyVerticalMotion;
    [SerializeField] private AudioClip conceptsOf1DApplicable;
    [SerializeField] private AudioClip onlyHorizontalObservable;
    [Header("Tasks")]
    [SerializeField] private AudioClip coolPressHorizontalCam;
    [SerializeField] private AudioClip launchBall;
    [SerializeField] private AudioClip pressToggleBackground;
    [SerializeField] private AudioClip clickVerticalCamera;
    [Header("Statements")]
    [SerializeField] private AudioClip nowWeMoveSideways;
    [SerializeField] private AudioClip nowWeMoveUpwards;

    private Dictionary<string, AudioClip> miscAudioClips;
    private Dictionary<string, Question> questions;
    private Dictionary<string, Task> tasks;

    [SerializeField] private AudioClip[] appreciations;

    private void Start()
    {
        miscAudioClips = new Dictionary<string, AudioClip>
        {
            { "introduction", introduction },
            { "nowWeMoveSideways", nowWeMoveSideways },
            { "nowWeMoveUpwards", nowWeMoveUpwards}
        };

        questions = new Dictionary<string, Question>
        {
            { "whatTrajectory", new Question
                {
                    QuestionAudio = whatTrajectory,
                    QuestionString = "What was the trajectory of the ball (till the first bounce) ?",
                    Options = new[] { "Straight Line", "Circular", "Curved but not circular" },
                    CorrectOptionIndex = 2,
                    OptionTips = new[] { "No", "No", "Correct !" },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "whyCurved", new Question
                {
                    QuestionAudio = whyCurved,
                    QuestionString = "Why do you think the trajectory was curved?",
                    Options = new[] { "Ball's Elasticity", "Earth's Magnetic Force", "Earth's Gravity" },
                    CorrectOptionIndex = 2,
                    OptionTips = new[] { "No", "No", "Correct !" },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "howManyAxes", new Question
                {
                    QuestionAudio = howManyAxes,
                    QuestionString = "So, if the path is curved, along how many axes is the ball moving in?",
                    Options = new[] { "1 (Horizontal Only)", "2 (Horizontal and Vertical)", "1 (Vertical Only)" },
                    CorrectOptionIndex = 1,
                    OptionTips = new[] { "No", "Correct !", "No" },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "noticeOnlyVerticalMotion", new Question
                {
                    QuestionAudio = noticeOnlyVerticalMotion,
                    QuestionString = "Since we are moving along with the ball sideways, can you notice that the ball is moving only vertically?",
                    Options = new[] { "Nah, let me try again", "Oh wow ! I see it !" },
                    CorrectOptionIndex = 1,
                    OptionTips = new[] { "", "", "" },
                    IsPausable = true,
                    IsAnsweredCorrectly = false
                }
            },
            { "conceptsOf1DApplicable", new Question
                {
                    QuestionAudio = conceptsOf1DApplicable,
                    QuestionString = "Since we are observing only a one dimensional motion right now, can't we apply the concepts of 1-D motion?",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "onlyVerticalObservable", new Question
                {
                    QuestionString = "Actually, the ball is still moving in two dimensions. But since we are moving sideways along with the ball, its relative horizontal velocity with respect to us is zero. Hence, we can only notice the vertical motion of the ball.",
                    Options = new[] { "Got it!", "What?" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our X velocity is same as ball's X velocity, we can only observe the Y velocity of the ball." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "onlyHorizontalObservable", new Question
                {
                    QuestionAudio = onlyHorizontalObservable,
                    QuestionString = "As you can see, only the horizontal motion of the ball is now observable.",
                    Options = new[] { "Got it!", "What?" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our Y velocity is same as ball's Y velocity, we can only observe the X velocity of the ball." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            }
        };

        tasks = new Dictionary<string, Task>
        {
            { "coolPressHorizontalCam", new Task
                {
                    TaskAudio = coolPressHorizontalCam,
                    TaskString = "Cool. Let me show you something. Press the horizontal camera button.",
                    IsCompleted = () => UIManager.mostRecentlyClickedButton == "Horizontal"
                }
            },
            { "launchBall", new Task
                {
                    TaskAudio = launchBall,
                    TaskString = "Now launch the ball again.",
                    IsCompleted = () => BallController.hasBouncedOnce
                }
            },
            { "pressToggleBackground", new Task
                {
                    TaskAudio = pressToggleBackground,
                    TaskString = "I want you to observe something interesting about the movement of the ball. Go ahead and press the toggle background button.",
                    IsCompleted = () => UIManager.mostRecentlyClickedButton == "Toggle Background"
                }
            },
            { "clickVerticalCamera", new Task
                {
                    TaskAudio = clickVerticalCamera,
                    TaskString = "Now go ahead and click the vertical camera button.",
                    IsCompleted = () => UIManager.mostRecentlyClickedButton == "Vertical"
                }
            }
        };
    }

    public Question GetQuestion(string questionKey)
    {
        return questions[questionKey];
    }

    public Task GetTask(string taskKey)
    {
        return tasks[taskKey];
    }

    public AudioClip GetMiscAudioClip(string clipKey)
    {
        return miscAudioClips[clipKey];
    }

    public AudioClip GetRandomAppreciation()
    {
        return appreciations[new System.Random(System.DateTime.Now.Millisecond).Next(appreciations.Length)];
    }
}
