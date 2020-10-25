using UnityEngine;
using UnityEngine.UI;

//remeber to use cartoon figures with questions/explanations etc
//dynamic button functionality can be added. Currently 4 options need to be present.
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject metricsPanel;
    [SerializeField] private GameObject bottomPanel;
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private QuizPanelController quizPanelControllerNew;

    public static string mostRecentlyClickedButton;

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
        metricsPanelController = metricsPanel.GetComponent<MetricsPanelController>();
        mostRecentlyClickedButton = string.Empty;
        notificationTextBox = notificationPanel.transform.Find("NotificationBar").Find("Text").GetComponent<Text>();
    }

    public void DisplayQuestion(string questionKey)
    {
        quizPanelControllerNew.DisplaySimpleMCQ(questionKey);
    }

    public void DisplayExplanation(Explanation explanation)
    {
        //explanationPanel.SetActive(true);
        currentExplanation = explanation;
        explanationPanelController.DisplayExplanationImage(explanation.ExplanationImage);
        explanationPanelController.DisplayExplanationText(explanation.ExplanationText);
    }

    public void MarkCurrentExplanationUnderstood()
    {
        currentExplanation.IsUnderstood = true;
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
