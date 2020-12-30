using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lean.Gui;

/* 
 * New instance of this class will sit on each type of question panels (mcq/explanation etc)
 * and expose the methods to set the UI container values.
 */
public class GenericQuestionUIExposer : MonoBehaviour
{
    [SerializeField] private TEXDraw mainTextContainer;
    [SerializeField] private TEXDraw option1Container;
    [SerializeField] private TEXDraw option2Container;
    [SerializeField] private TEXDraw option3Container;
    [SerializeField] private TEXDraw option4Container;
    [SerializeField] private TEXDraw explanationTextContainer;
    [SerializeField] private TEXDraw tipTextContainer;
    [SerializeField] private GameObject imageContainer;

    public void ShowCurrentQuestion()
    {
        Question question = Dialogues.GetQuestion(GameState.currentQuestionName);
        mainTextContainer.text = question.mainText;
        if (option1Container != null)
        {
            option1Container.text = question.options[0].text;
            option2Container.text = question.options[1].text;
            option3Container.text = question.options[2].text;
            option4Container.text = question.options[3].text;
        }
        if (imageContainer != null)
        {
            GameObject imageInstance = Instantiate(question.image, imageContainer.transform);
            imageInstance.transform.SetParent(imageContainer.transform);
        }
        if (explanationTextContainer != null)
        {
            explanationTextContainer.text = question.explanation;
        }
    }

    public void ShowTipText(string tipText)
    {
        tipTextContainer.text = tipText;
    }
}
