using UnityEngine;

public class QuizPanelControllerNew : MonoBehaviour
{
    [SerializeField] private GameObject simpleMCQPanel;
    [SerializeField] private GameObject imageMCQPanel;
    [SerializeField] private GameObject longOptionMCQPanel;
    [SerializeField] private GameObject imageExplanationPanel;
    [SerializeField] private GameObject simpleExplanationPanel;

    private Question currentQuestion;
    private GenericQuestionUIExposer currentPanelUIExposer;

    public void DisplaySimpleMCQ(Question question)
    {
        currentQuestion = question;
        simpleMCQPanel.SetActive(true);
        DisplayQuestionOnPanel(question, simpleMCQPanel);
    }

    private void DisplayQuestionOnPanel(Question question, GameObject panel)
    {
        currentPanelUIExposer = panel.GetComponent<GenericQuestionUIExposer>();
        currentPanelUIExposer.SetQuestionText(question.QuestionString);
        currentPanelUIExposer.SetOption1Text(question.Options[0]);
        currentPanelUIExposer.SetOption2Text(question.Options[1]);
        currentPanelUIExposer.SetOption3Text(question.Options[2]);
        currentPanelUIExposer.SetOption4Text(question.Options[3]);
    }

    public void CheckAnswer(int optionNumber)
    {
        if (optionNumber == currentQuestion.CorrectOptionNumber)
        {
            currentQuestion.HasBeenAnsweredCorrectly = true;
        }
        currentPanelUIExposer.SetHintText(currentQuestion.OptionTips[optionNumber - 1]);
    }
}
