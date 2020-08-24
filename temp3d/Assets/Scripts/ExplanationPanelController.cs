using UnityEngine;
using UnityEngine.UI;

public class ExplanationPanelController : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject flashCard;
    [SerializeField] private GameObject imagePanel;
    [SerializeField] private Text explanationText;

    public void DisplayExplanationText(string text)
    {
        explanationText.text = text;
    }

    public void DisplayExplanationImage(GameObject image)
    {
        image.transform.parent = imagePanel.transform;
    }
}
