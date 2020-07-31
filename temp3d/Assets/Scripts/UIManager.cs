using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private GameObject quantitiesPanel;
    [SerializeField] private GameObject bottomPanel;

    public static string mostRecentlyClickedButton;

    private QuizPanelController quizPanelController;
    private QuantitiesPanelController quantitiesPanelController;

    private Question currentQuestion;

    private void Start()
    {
        quizPanel.SetActive(false);
        quizPanelController = quizPanel.GetComponent<QuizPanelController>();
        quantitiesPanelController = quantitiesPanel.GetComponent<QuantitiesPanelController>();
        mostRecentlyClickedButton = string.Empty;
    }

    public void DisplayQuestion(Question question)
    {
        currentQuestion = question;
        quizPanel.SetActive(true);
        quizPanelController.DisplayTip("");
        quizPanelController.DisplayQuestion(question.QuestionString);
        quizPanelController.DisplayOptions(question.Options, CheckAnswer);
    }

    private void CheckAnswer(int index)
    {
        quizPanelController.DisplayTip(currentQuestion.OptionTips[index]);
        if(currentQuestion.CorrectOptionIndex == index)
        {
            currentQuestion.IsAnsweredCorrectly = true;
            quizPanel.SetActive(false);
        }
    }

    public void IsClicked(GameObject button)
    {
        mostRecentlyClickedButton = button.name;
    }

    public void DisplayVelocityAndAngle(double initialVelocity, double initialAngle)
    {
        quantitiesPanelController.DisplayInitialVelocity("Initial Velocity: " + initialVelocity.ToString("F1") + " m/s");
        quantitiesPanelController.DisplayInitialAngle("Initial Angle: " + initialAngle.ToString("F1") + " deg");
    }

    public void DisplayRangeAndMaxHeight(double range, double maxHeight)
    {
        quantitiesPanelController.DisplayRange("Range: " + range.ToString("F1") + " m");
        quantitiesPanelController.DisplayMaxHeight("MaxHeight: " + maxHeight.ToString("F1") + " m");
    }
}
