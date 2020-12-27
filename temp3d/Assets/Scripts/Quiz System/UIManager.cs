using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Lean.Gui;

//remember to use cartoon figures with questions/explanations etc
//dynamic button functionality can be added. Currently 4 options need to be present.
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject metricsPanel;
    [SerializeField] private GameObject bottomPanel;
    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private QuizPanelController quizPanelController;
    private static QuizPanelController quizPanelControllerStatic;

    [SerializeField] private GameButtonToLeanButtonDictionary buttonMap;
    private static GameButtonToLeanButtonDictionary buttonMapStatic;

    private MetricsPanelController metricsPanelController;

    private Question currentQuestion;
    private Text notificationTextBox;

    private void Start()
    {
        quizPanelControllerStatic = quizPanelController;
        metricsPanelController = metricsPanel.GetComponent<MetricsPanelController>();
        notificationTextBox = notificationPanel.transform.Find("NotificationBar").Find("Text").GetComponent<Text>();
        buttonMapStatic = buttonMap;
    }

    /// <summary>
    /// Delegates display question task to QuizPanelController
    /// </summary>
    public static void DisplayCurrentQuestion()
    {
        quizPanelControllerStatic.DisplayCurrentQuestion();
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

    public static void HideAllButtonsExcept(GameButton gameButton)
    {
        foreach (KeyValuePair<GameButton, LeanButton> gameButtonAndLeanButton in buttonMapStatic)
        {
            if (gameButtonAndLeanButton.Key == gameButton)
            {
                gameButtonAndLeanButton.Value.gameObject.SetActive(true);
            }
            else
            {
                gameButtonAndLeanButton.Value.gameObject.SetActive(false);
            }
        }
    }

    public static void ShowAllButtons()
    {
        foreach (KeyValuePair<GameButton, LeanButton> gameButtonAndLeanButton in buttonMapStatic)
        {
            gameButtonAndLeanButton.Value.gameObject.SetActive(true);
        }
    }

    public static void ShowBackground()
    {
        buttonMapStatic[GameButton.TOGGLE_BACKGROUND].gameObject.GetComponent<LeanToggle>().On = true;
    }
}
