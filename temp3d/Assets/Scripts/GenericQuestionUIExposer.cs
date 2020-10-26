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
    [SerializeField] private TextMeshProUGUI mainTextContainer;
    [SerializeField] private TextMeshProUGUI option1Container;
    [SerializeField] private TextMeshProUGUI option2Container;
    [SerializeField] private TextMeshProUGUI option3Container;
    [SerializeField] private TextMeshProUGUI option4Container;
    [SerializeField] private TextMeshProUGUI secondaryTextContainer;
    [SerializeField] private GameObject imageContainer;

    public void ShowQuestion(Question question)
    {
        mainTextContainer.text = question.text;
        if (option1Container != null)
        {
            option1Container.text = question.options[0].text;
            option2Container.text = question.options[1].text;
            option3Container.text = question.options[2].text;
            option4Container.text = question.options[3].text;
        }
        if (imageContainer != null)
        {
            question.image.transform.SetParent(imageContainer.transform);
        }
    }

    public void ShowSecondaryText(string secondaryText)
    {
        secondaryTextContainer.text = secondaryText;
    }
}
