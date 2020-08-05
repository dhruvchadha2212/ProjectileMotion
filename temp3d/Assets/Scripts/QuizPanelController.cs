using System;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanelController : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private GameObject optionsBox;
    [SerializeField] private Text tipText;
    [SerializeField] private GameObject buttonPrefab;
    
    public void DisplayQuestion(string question)
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
}
