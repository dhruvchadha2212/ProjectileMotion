using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Will sit on all types of question panels (mcq/explanation etc) and expose the methods to set the UI container values.
public class GenericQuestionUIExposer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionContainer;
    [SerializeField] private TextMeshProUGUI option1Container;
    [SerializeField] private TextMeshProUGUI option2Container;
    [SerializeField] private TextMeshProUGUI option3Container;
    [SerializeField] private TextMeshProUGUI option4Container;
    [SerializeField] private TextMeshProUGUI hintContainer;
    [SerializeField] private GameObject imageContainer;

    public void SetQuestionText(string questionText)
    {
        questionContainer.text = questionText;
    }

    public void SetOption1Text(string option1Text)
    {
        option1Container.text = option1Text;
    }

    public void SetOption2Text(string option2Text)
    {
        option2Container.text = option2Text;
    }

    public void SetOption3Text(string option3Text)
    {
        option3Container.text = option3Text;
    }

    public void SetOption4Text(string option4Text)
    {
        option4Container.text = option4Text;
    }

    public void SetHintText(string hintText)
    {
        hintContainer.text = hintText;
    }

    public void SetImage(Image image)
    {
        image.transform.SetParent(imageContainer.transform);
    }
}
