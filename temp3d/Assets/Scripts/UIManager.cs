using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private GameObject explanationPanel;
    [SerializeField] private GameObject metricsPanel;
    [SerializeField] private GameObject bottomPanel;
    [SerializeField] private GameObject notificationPanel;

    public static string mostRecentlyClickedButton;

    private QuizPanelController quizPanelController;
    private MetricsPanelController metricsPanelController;
    private ExplanationPanelController explanationPanelController;

    private Question currentQuestion;
    private Explanation currentExplanation;
    private Text notificationTextBox;

    public void setMostRecentlyClickedButton(Text clickedButtonText)
    {
        mostRecentlyClickedButton = clickedButtonText.text;
    }

    private void Start()
    {
        quizPanel.SetActive(false);
        quizPanelController = quizPanel.GetComponent<QuizPanelController>();
        metricsPanelController = metricsPanel.GetComponent<MetricsPanelController>();
        explanationPanelController = explanationPanel.GetComponent<ExplanationPanelController>();
        mostRecentlyClickedButton = string.Empty;
        notificationTextBox = notificationPanel.transform.Find("NotificationBar").Find("Text").GetComponent<Text>();
    }

    public void DisplayQuestion(Question question)
    {
        currentQuestion = question;
        quizPanel.SetActive(true);
        quizPanelController.DisplayTip("");
        quizPanelController.DisplayQuestionText(question.QuestionString);
        quizPanelController.DisplayOptions(question.Options, CheckAnswer);
    }

    public void DisplayExplanation(Explanation explanation)
    {
        explanationPanel.SetActive(true);
        currentExplanation = explanation;
        explanationPanelController.DisplayExplanationImage(explanation.ExplanationImage);
        explanationPanelController.DisplayExplanationText(explanation.ExplanationText);
    }

    public void MarkCurrentExplanationUnderstood()
    {
        currentExplanation.IsUnderstood = true;
    }

    private void CheckAnswer(int index)
    {
        if(currentQuestion.OptionTips != null)
        {
            quizPanelController.DisplayTip(currentQuestion.OptionTips[index]);
        }
        if(currentQuestion.CorrectOptionIndex == index)
        {
            currentQuestion.IsAnsweredCorrectly = true;
            quizPanel.SetActive(false);
        } else
        {
            if (currentQuestion.IsPausable)
            {
                quizPanelController.SetFlashCardActive(false);
                quizPanelController.SetResumeButtonActive(true);
                transform.parent.GetComponent<Direction>().audioManager.StopPlayingAudio();
            }
        }
    }

    public void IsClicked(GameObject button)
    {
        mostRecentlyClickedButton = button.name;
    }

    public void DisplayVelocityAndAngle(double initialVelocity, double initialAngle)
    {
        metricsPanelController.DisplayInitialVelocity("Initial Velocity: " + initialVelocity.ToString("F1") + " m/s");
        metricsPanelController.DisplayInitialAngle("Initial Angle: " + initialAngle.ToString("F1") + " deg");
    }

    public void DisplayRangeAndMaxHeight(double range, double maxHeight)
    {
        metricsPanelController.DisplayRange("Range: " + range.ToString("F1") + " m");
        metricsPanelController.DisplayMaxHeight("MaxHeight: " + maxHeight.ToString("F1") + " m");
    }

    public void ShowNotification(string notificationText)
    {
        notificationTextBox.text = notificationText;
        notificationPanel.GetComponent<Lean.Gui.LeanPulse>().Pulse();
    }
}
