using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class is responsible only for the display of the 'text' of questions/options/tips and the visibility of the components.
 */

/* 
 * Types of quiz panels -
 * pure question
 * pausable question (to reconfirm whether player understood)
 * pure explanation (not ending in a question mark) (probably use explanation card sort of thing, with cartoons) (also pausible)
 * 
 * for pure explanation scenario, change question mark on top to a exclamation mark or magnifying glass.
 */
public class QuizPanelController : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject flashCard;
    [SerializeField] private Text questionText;
    [SerializeField] private GameObject optionsBox;
    [SerializeField] private Text tipText;
    [SerializeField] private GameObject buttonPrefab;
    
    public void DisplayQuestionText(string question)
    {
        questionText.text = question;
    }

    public void DisplayOptions(string[] options, Action<int> CheckAnswer)
    {
        RemoveOldButtons();
        int numOfOptions = options.Length;
        for (int index = 0; index < numOfOptions; index++)
        {
            GameObject optionButton = Instantiate(buttonPrefab);
            int currentIndex = index; //required for lambda to take current index value on next line
            optionButton.GetComponent<Lean.Gui.LeanButton>().OnClick.AddListener(() => CheckAnswer(currentIndex));
            optionButton.GetComponentInChildren<Text>().text = options[index];
            optionButton.transform.SetParent(optionsBox.transform, false);
            PositionButton(optionButton, index, numOfOptions);
        }
    }

    public void DisplayTip(string tip)
    {
        tipText.text = tip;
    }

    private void RemoveOldButtons()
    {
        for (int i = 0; i < optionsBox.transform.childCount; i++)
        {
            Destroy(optionsBox.transform.GetChild(i).gameObject);
        }
    }

    private void PositionButton(GameObject optionButton, int index, int numOfOptions)
    {
        float optionsBoxWidth = optionsBox.GetComponent<RectTransform>().rect.width;
        float buttonWidth = optionButton.GetComponent<RectTransform>().rect.width;

        float buttonPositionX = (buttonWidth / 2) - (optionsBoxWidth / 2) + 
            (index * optionsBoxWidth) / numOfOptions + 
            (optionsBoxWidth / numOfOptions - buttonWidth) / 2; 

        optionButton.transform.localPosition = new Vector3(buttonPositionX, 0, 0);
    }

    public void SetFlashCardActive(bool isActive)
    {
        flashCard.GetComponent<Lean.Gui.LeanWindow>().TurnOff();
    }

    public void SetResumeButtonActive(bool isActive)
    {
        resumeButton.SetActive(isActive);
    }
}
