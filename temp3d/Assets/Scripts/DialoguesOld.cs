using System.Collections.Generic;
using UnityEngine;

public class DialoguesOld : MonoBehaviour
{
    [Header("Introduction")]
    [SerializeField] private AudioClip introduction;
    [Header("General Questions")]
    [SerializeField] private AudioClip whatTrajectory;
    [SerializeField] private AudioClip whyCurved;
    [SerializeField] private AudioClip howManyAxes;
    [Header("Only Vertical Motion")]
    [SerializeField] private AudioClip noticeOnlyVerticalMotion;
    [SerializeField] private AudioClip verticalIsIndependent;
    [SerializeField] private AudioClip apply1DToVertical;
    [SerializeField] private AudioClip verticalComponentFormula;
    [SerializeField] private AudioClip timeOfFlightCanBeFound;
    [SerializeField] private AudioClip whichEquationTimeOfFlight;
    [Header("Only Horizontal Motion")]
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
            //{ "whatTrajectory", new Question
            //    {
            //        audio = whatTrajectory,
            //        text = "What was the trajectory of the ball (till the first bounce) ?",
            //        Options = new[] { "Straight Line", "Circular", "Curved but not circular", "None of the above" },
            //        CorrectOptionNumber = 3,
            //        OptionTips = new[] { "No", "No", "Correct !", "No" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "whyCurved", new Question
            //    {
            //        audio = whyCurved,
            //        text = "Why do you think the trajectory was curved?",
            //        Options = new[] { "Ball's Elasticity", "Earth's Magnetic Force", "Earth's Gravity" },
            //        CorrectOptionNumber = 3,
            //        OptionTips = new[] { "No", "No", "Correct !" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "howManyAxes", new Question
            //    {
            //        audio = howManyAxes,
            //        text = "So, if the path is curved, along how many (directions) axes is the ball moving in?",
            //        Options = new[] { "1 (Horizontal Only)", "2 (Horizontal and Vertical)", "1 (Vertical Only)" },
            //        CorrectOptionNumber = 2,
            //        OptionTips = new[] { "No", "Correct !", "No" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "noticeOnlyVerticalMotion", new Question
            //    {
            //        audio = noticeOnlyVerticalMotion,
            //        text = "Since we are moving along with the ball sideways, can you notice that the ball seems to be moving only vertically?",
            //        Options = new[] { "Nah, let me try again", "Oh wow ! I see it !" },
            //        CorrectOptionNumber = 2,
            //        OptionTips = new[] { "", "", "" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "verticalIsIndependent", new Question
            //    {
            //        audio = verticalIsIndependent,
            //        text = "If the ball seems to be moving only vertically, which of the following is not true?",
            //        Options = new[]
            //        {
            //            "Gravity is the one and only external accelerator affecting the vertical velocity of the ball (ignore any air resistance).",
            //            "The horizontal motion interferes with the vertical motion of the ball, and affects its vertical speed and acceleration.",
            //            "We can apply equations of 1-D motion on only the vertical motion of the ball (that is, on the vertical speed and vertical acceleration)."

            //        },
            //        CorrectOptionNumber = 2,
            //        OptionTips = new[]
            //        {
            //            "No, this statement is true. There is no other accelerator apart from gravity.",
            //            "Correct! The ball's horizontal motion has nothing to do with the vertical motion. They are in their own inpendent axes!",
            //            "No, this statement is true. The 3 equations of motion can be applied of the vertical motion of the ball."
            //        },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "verticalComponentFormula", new Question
            //    {
            //        audio = verticalComponentFormula,
            //        text = "Lets say that the ball was launched with an initial velocity of 'u' at an angle 'theta'. What would have been the vertical component of its initial velocity?",
            //        Options = new[] { "Sample", "Sample" },
            //        CorrectOptionNumber = 1,
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "timeOfFlightCanBeFound", new Question
            //    {
            //        audio = timeOfFlightCanBeFound,
            //        text = "Which of the following can we calculate from analysing just the vertical motion of the ball?",
            //        Options = new[] {
            //            "It's Range (How far the ball goes before it hits the ground.",
            //            "It's Rotational speed (Angular velocity).",
            //            "It's Time of Flight. (How long it remains in the air before hitting the ground.",
            //            "The final angle between the ball's velocity vector and the ground, when it hits the ground."
            //        },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[] { "Correct !", "We are independently observing the vertical motion of the ball. Since its a simple motion in 1 dimension, we can apply the concepts of 1-D motion." },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "whichEquationTimeOfFlight", new Question
            //    {
            //        audio = whichEquationTimeOfFlight,
            //        text = "Let's see if you remember. Which equation can be used to find the time of flight of the ball? (remember Vx = VcosTheta)",
            //        Options = new[] { "Sample", "Sample" },
            //        CorrectOptionNumber = 1,
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            ////level 1 cleared, time of flight formula is ->
            //{ "noticeOnlyHorizontalMotion", new Question
            //    {
            //        audio = noticeOnlyHorizontalMotion,
            //        text = "As you can see, only the horizontal motion of the ball is now observable.",
            //        Options = new[] { "Got it!", "What?" },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[] { "Correct !", "The ball moves in X and Y direction. But since our Y velocity is same as ball's Y velocity, we can only observe the X velocity of the ball." },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "anyHorizontalForce", new Question
            //    {
            //        audio = anyHorizontalForce,
            //        text = "Assuming there is no air resistance, is there any other force affecting the horizontal speed of the ball, while it is in the air?",
            //        Options = new[] { "Yes, gravity", "Floor's friction", "No force affects the horizontal motion" },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[]
            //        {
            //            "Gravity doesn't affect the horizontal speed, only the vertical speed.",
            //            "Floor's friction cannot affect the ball's movement, unless it is in contact with the floor.",
            //            "Correct!"
            //        },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "isHorizontalVelocityAffected", new Question
            //    {
            //        audio = isHorizontalVelocityAffected,
            //        text = "If there is no force on the ball in horizontal direction, what will happen to its initial velocity ?",
            //        Options = new[] { "It will decelerate naturally", "It will maintain constant speed", "It will accelerate due to gravity" },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[]
            //        {
            //            "Nope, no force on the ball. No change in speed (Newton's second law of motion)",
            //            "Correct! No force on the ball. No change in speed (Newton's second law of motion)",
            //            "Nope, no force on the ball. No change in speed (Newton's second law of motion)",
            //        },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "horizontalComponentFormula", new Question
            //    {
            //        audio = horizontalComponentFormula,
            //        text = "Again, if the ball is launched with an initial velocity of 'u' at an angle 'theta', what will be the horizontal component of its initial velocity ?",
            //        Options = new[] { "Sample", "Sample" },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[] { "", "" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "rangeCanBeFound", new Question
            //    {
            //        audio = rangeCanBeFound,
            //        text = "Which of the following can we calculate from analysing just the horizontal motion of the ball (given that we know the time of flight from analysing the vertical motion)?",
            //        Options = new[]
            //        {
            //            "It's Range (How far the ball goes before it hits the ground.",
            //            "It's Rotational speed (Angular velocity).",
            //            "It's Time of Flight. (How long it remains in the air before hitting the ground.",
            //            "The final angle between the ball's velocity vector and the ground, when it hits the ground."
            //        },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[] { "" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //},
            //{ "rangeFormula", new Question
            //    {
            //        audio = rangeFormula,
            //        text = "Here's the final question. Performing which of the following operations will give you the range covered by the ball (up until the first bounce) ?",
            //        Options = new[] { "Sample", "Sample" },
            //        CorrectOptionNumber = 1,
            //        OptionTips = new[] { "", "" },
            //        HasBeenAnsweredCorrectly = false
            //    }
            //}
        };
        //excellent, range of projectile is ->
        explanations = new Dictionary<string, Explanation>
        {
            { "onlyVerticalObservable", new Explanation
                {
                    ExplanationText = "Actually the ball is still moving in 2 dimensions. But since we are moving at a horizontal velocity equal to that of the ball, it seems to be in a simple vertical motion.",
                    ExplanationImage = onlyVerticalObservable,
                    IsUnderstood = false
                }
            },
            { "onlyHorizontalObservable", new Explanation
                {
                    ExplanationText = "Again, the ball is still actually moving in 2 dimensions. But since we move vertically up and down along with the ball, it seems to be moving simply horizontally.",
                    ExplanationImage = onlyHorizontalObservable,
                    IsUnderstood = false
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
