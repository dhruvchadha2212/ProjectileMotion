using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameButton mostRecentlyClickedGameButton;
    public static QuestionName currentQuestionName;
    public static bool ballIsJustLaunched = false;
    public static bool ballHasBouncedOnce = false;

    //Method for UI buttons to access
    public void SetMostRecentlyClickedGameButton(ButtonInfo clickedButton)
    {
        mostRecentlyClickedGameButton = clickedButton.GetGameButton();
    }
}
