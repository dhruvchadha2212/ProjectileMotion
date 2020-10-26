using UnityEngine;
using Lean.Gui;

/*
 * Responsible for controlling which panel type to display, and other question related activity like checking answer etc;
 */
public class QuizPanelController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject simpleMCQPanel;
    [SerializeField] private GameObject imageMCQPanel;
    [SerializeField] private GameObject longOptionMCQPanel;
    [SerializeField] private GameObject imageExplanationPanel;
    [SerializeField] private GameObject simpleExplanationPanel;
    [SerializeField] private GameObject resumeButton;

    private Question currentQuestion;
    private GameObject currentPanel;
    private GenericQuestionUIExposer currentPanelUIExposer;
    public static bool currentQuestionHasBeenAnsweredCorrectly;

    public void DisplaySimpleMCQ(string questionKey)
    {
        currentQuestion = Dialogues.GetQuestion(questionKey);
        currentQuestionHasBeenAnsweredCorrectly = false;
        currentPanel = simpleMCQPanel;
        currentPanel.GetComponent<LeanWindow>().TurnOn();
        pauseButton.SetActive(true);
        currentPanelUIExposer = simpleMCQPanel.GetComponent<GenericQuestionUIExposer>();
        currentPanelUIExposer.ShowQuestion(currentQuestion);
    }

    public void CheckAnswer(int optionNumber)
    {
        if (currentQuestion.options[optionNumber-1].isCorrect)
        {
            currentQuestionHasBeenAnsweredCorrectly = true;
            currentPanel.GetComponent<LeanWindow>().On = false;
            pauseButton.SetActive(false);
        }
        currentPanelUIExposer.ShowSecondaryText(currentQuestion.options[optionNumber - 1].tip);
    }

    public void PauseCurrentQuestion()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        currentPanel.GetComponent<LeanWindow>().TurnOff();
    }

    public void ResumeCurrentQuestion()
    {
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        currentPanel.GetComponent<LeanWindow>().TurnOn();
    }

    //// in case first question had 4 options and next had 3, the last option will still
    //// show from prev question, so remove previous options first.
    //public void DisplayOptions(string[] options, Action<int> CheckAnswer)
    //{
    //    RemoveOldButtons();
    //    int numOfOptions = options.Length;
    //    for (int index = 0; index < numOfOptions; index++)
    //    {
    //        GameObject optionButton = Instantiate(buttonPrefab);
    //        int currentIndex = index; //required for lambda to take current index value on next line
    //        optionButton.GetComponent<Lean.Gui.LeanButton>().OnClick.AddListener(() => CheckAnswer(currentIndex));
    //        optionButton.GetComponentInChildren<Text>().text = options[index];
    //        optionButton.transform.SetParent(optionsBox.transform, false);
    //        PositionButton(optionButton, index, numOfOptions);
    //    }
    //}

    //private void PositionButton(GameObject optionButton, int index, int numOfOptions)
    //{
    //    float optionsBoxWidth = optionsBox.GetComponent<RectTransform>().rect.width;
    //    float buttonWidth = optionButton.GetComponent<RectTransform>().rect.width;

    //    float buttonPositionX = (buttonWidth / 2) - (optionsBoxWidth / 2) +
    //        (index * optionsBoxWidth) / numOfOptions +
    //        (optionsBoxWidth / numOfOptions - buttonWidth) / 2;

    //    optionButton.transform.localPosition = new Vector3(buttonPositionX, 0, 0);
    //}
}
