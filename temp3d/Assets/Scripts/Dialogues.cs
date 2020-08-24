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
    [SerializeField] private AudioClip verticalIsIndependent;
    [SerializeField] private AudioClip apply1DToVertical;
    [SerializeField] private AudioClip verticalComponentFormula;
    [SerializeField] private AudioClip timeOfFlightCanBeFound;
    [SerializeField] private AudioClip whichEquationTimeOfFlight;
    [SerializeField] private AudioClip noticeOnlyHorizontalMotion;
    [SerializeField] private AudioClip anyHorizontalForce;
    [SerializeField] private AudioClip isHorizontalVelocityAffected;
    [SerializeField] private AudioClip horizontalComponentFormula;
    [SerializeField] private AudioClip rangeCanBeFound;
    [SerializeField] private AudioClip rangeFormula;
    [Header("Explanation Images")]
    [SerializeField] private GameObject onlyVerticalObservable;
    [SerializeField] private GameObject onlyHorizontalObservable;
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
    private Dictionary<string, Explanation> explanations;
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
                    QuestionString = "Since we are moving along with the ball sideways, can you notice that the ball seems to be moving only vertically?",
                    Options = new[] { "Nah, let me try again", "Oh wow ! I see it !" },
                    CorrectOptionIndex = 1,
                    OptionTips = new[] { "", "", "" },
                    IsPausable = true,
                    IsAnsweredCorrectly = false
                }
            },
            { "verticalIsIndependent", new Question
                {
                    QuestionAudio = verticalIsIndependent,
                    QuestionString = "This means that the vertical motion of the ball is just a simple 1-D motion, and is not affected by the horizontal motion of the ball.",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "apply1DToVertical", new Question
                {
                    QuestionAudio = apply1DToVertical,
                    QuestionString = "This means that we can apply equations of 1-D motion independently, to only the vertical motion of the ball.",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "verticalComponentFormula", new Question
                {
                    QuestionAudio = verticalComponentFormula,
                    QuestionString = "Lets say that the ball was launched with an initial velocity of 'u' at an angle 'theta'. What would have been the vertical component of its initial velocity?",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "timeOfFlightCanBeFound", new Question
                {
                    QuestionAudio = timeOfFlightCanBeFound,
                    QuestionString = "Which of the following can we calculate from analysing just the vertical motion of the ball?",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "whichEquationTimeOfFlight", new Question
                {
                    QuestionAudio = whichEquationTimeOfFlight,
                    QuestionString = "Let's see if you remember. Which equation can be used to find the time of flight of the ball? (remember Vx = VcosTheta)",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "noticeOnlyHorizontalMotion", new Question
                {
                    QuestionAudio = noticeOnlyHorizontalMotion,
                    QuestionString = "As you can see, the ball seems to be moving only horizontally",
                    Options = new[] { "Got it!", "What?" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our Y velocity is same as ball's Y velocity, we can only observe the X velocity of the ball." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "anyHorizontalForce", new Question
                {
                    QuestionAudio = anyHorizontalForce,
                    QuestionString = "Assuming there is no air resistance, is there any other force applicable on the ball in the horizontal direction?",
                    Options = new[] { "Got it!", "What?" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our Y velocity is same as ball's Y velocity, we can only observe the X velocity of the ball." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "isHorizontalVelocityAffected", new Question
                {
                    QuestionAudio = isHorizontalVelocityAffected,
                    QuestionString = "If there is no force on the ball in horizontal direction, what will happen to its initial velocity ?",
                    Options = new[] { "Got it!", "What?" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our Y velocity is same as ball's Y velocity, we can only observe the X velocity of the ball." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "horizontalComponentFormula", new Question
                {
                    QuestionAudio = horizontalComponentFormula,
                    QuestionString = "Again, if the ball is launched with an initial velocity of 'u' at an angle 'theta', what will be the horizontal component of its initial velocity ?",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "rangeCanBeFound", new Question
                {
                    QuestionAudio = rangeCanBeFound,
                    QuestionString = "Which of the following can we calculate from analysing just the horizontal motion of the ball ?",
                    Options = new[] { "Range of the ball (till first bounce)", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            },
            { "rangeFormula", new Question
                {
                    QuestionAudio = rangeFormula,
                    QuestionString = "Here's the final question. Performing which of the following operations will give you the range covered by the ball (up until the first bounce) ?",
                    Options = new[] { "Oh yeah!", "No" },
                    CorrectOptionIndex = 0,
                    OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
                    IsPausable = false,
                    IsAnsweredCorrectly = false
                }
            }
        };

        explanations = new Dictionary<string, Explanation>
        {
            { "onlyVerticalObservable", new Explanation
                {
                    ExplanationText = "Actually the ball is still moving in 2 dimensions. But since we are moving at a horizontal velocity equal to that of the ball, it seems to be in a simple vertical motion.",
                    ExplanationImage = onlyVerticalObservable   
                }
            },
            { "onlyHorizontalObservable", new Explanation
                {
                    ExplanationText = "Again, the ball is still actually moving in 2 dimensions. But since we move vertically up and down along with the ball, it seems to be moving simply horizontally.",
                    ExplanationImage = onlyHorizontalObservable
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

    public Explanation GetExplanation(string explanationKey)
    {
        return explanations[explanationKey];
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
