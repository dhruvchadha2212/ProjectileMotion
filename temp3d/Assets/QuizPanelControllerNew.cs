using UnityEngine;

public class QuizPanelControllerNew : MonoBehaviour
{
    [SerializeField] private GameObject simpleMCQPanel;
    [SerializeField] private GameObject imageMCQPanel;
    [SerializeField] private GameObject longOptionMCQPanel;
    [SerializeField] private GameObject imageExplanationPanel;
    [SerializeField] private GameObject simpleExplanationPanel;

    public void DisplaySimpleMCQ(Question question)
    {
        simpleMCQPanel.SetActive(true);
        DisplayQuestionOnPanel(question, simpleMCQPanel);
    }

    private void DisplayQuestionOnPanel(Question question, GameObject panel)
    {
        GenericQuestionUIExposer panelUIExposer = panel.GetComponent<GenericQuestionUIExposer>();
        panelUIExposer.SetQuestionText(question.QuestionString);
        panelUIExposer.SetOption1Text(question.Options[0]);
        panelUIExposer.SetOption2Text(question.Options[1]);
        panelUIExposer.SetOption3Text(question.Options[2]);
        panelUIExposer.SetOption4Text(question.Options[3]);
    }
}
